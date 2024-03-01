using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HuggingFace.API.Examples
{
    public class SpeechRecognition : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button stopButton;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private TextMeshProUGUI textSimilar;
        [SerializeField] private Brain brain;

        [SerializeField] private UnityEvent onSendRecording;

        public RunWhisper runWhisper; // This is the reference to the RunWhisper script

        private AudioClip clip;
        private int recordingLength = 4; // Longitud de la grabación en segundos
        private int sampleRate = 44100;
        //private byte[] bytes;
        //private bool recording;
        private bool isRecording = false;


        private void Start()
        {
            //startButton.onClick.AddListener(StartRecording);
            //stopButton.onClick.AddListener(StopRecording);
            //stopButton.interactable = false;
            StartRecordingLoop();
        }
        /*
        private void Update()
        {
            if (recording && Microphone.GetPosition(null) >= clip.samples)
            {
                StopRecording();
            }
        }

        private void StartRecording()
        {
            text.color = Color.white;
            text.text = "Recording...";
            startButton.interactable = false;
            stopButton.interactable = true;
            clip = Microphone.Start(null, false, 10, 44100);
            recording = true;
        }

        private void StopRecording()
        {
            var position = Microphone.GetPosition(null);
            Microphone.End(null);
            var samples = new float[position * clip.channels];
            clip.GetData(samples, 0);
            bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
            recording = false;
            SendRecording();
        }*/

        private void StartRecordingLoop()
        {
            isRecording = true;
            StartCoroutine(ContinuousRecording());
        }

        private IEnumerator ContinuousRecording()
        {
            yield return new WaitForSeconds(5);
            while (isRecording)
            {
                // Inicia la grabación
                clip = Microphone.Start(null, false, recordingLength, sampleRate);
                yield return new WaitForSeconds(recordingLength); // Espera la duración de la grabación.

                // Verifica si realmente se ha grabado algo
                if (Microphone.IsRecording(null))
                {
                    int endPosition = Microphone.GetPosition(null);
                    if (endPosition > 0)
                    {
                        // Procesa la grabación solo si hay datos
                        ProcessRecording(endPosition);
                    }
                    else
                    {
                        UnityEngine.Debug.LogWarning("Grabación terminada antes de procesar datos.");
                    }
                }
                else
                {
                    UnityEngine.Debug.LogError("El micrófono no está grabando. Verifique la configuración del micrófono o los permisos.");
                }

                Microphone.End(null); // Asegúrate de terminar la grabación actual antes de comenzar una nueva.
            }
        }


        private void ProcessRecording(int position)
        {
            // Asegúrate de que no estás procesando más datos de los disponibles.
            position = Mathf.Min(position, clip.samples);

            onSendRecording.Invoke();
            runWhisper.audioClip = clip;
            runWhisper.Transcribe();

            //var samples = new float[position * clip.channels];
            //clip.GetData(samples, 0);
            //var bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
            //SendRecording(bytes);
        }

        private void SendRecording(byte[] bytes)
        {
            text.color = Color.yellow;
            text.text = "Sending...";
            //stopButton.interactable = false;
            HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response => {
                text.color = Color.white;
                text.text = response;
                CalculateSimilarity(response);
                //startButton.interactable = true;
            }, error => {
                text.color = Color.red;
                text.text = error;
                //startButton.interactable = true;
            });
        }

        private void CalculateSimilarity(string recognizedText)
        {
            // Asumiendo que tienes un arreglo de frases candidatas
            string[] sentences = new string[] { "left", "hide", "right" };
            brain.RankSimilarityScores(recognizedText, sentences); // Esta llamada es asíncrona, necesitas ajustar tu código en Brain para manejar la respuesta y actualizar textSimilar adecuadamente
        }

        private byte[] EncodeAsWAV(float[] samples, int frequency, int channels)
        {
            using (var memoryStream = new MemoryStream(44 + samples.Length * 2))
            {
                using (var writer = new BinaryWriter(memoryStream))
                {
                    writer.Write("RIFF".ToCharArray());
                    writer.Write(36 + samples.Length * 2);
                    writer.Write("WAVE".ToCharArray());
                    writer.Write("fmt ".ToCharArray());
                    writer.Write(16);
                    writer.Write((ushort)1);
                    writer.Write((ushort)channels);
                    writer.Write(frequency);
                    writer.Write(frequency * channels * 2);
                    writer.Write((ushort)(channels * 2));
                    writer.Write((ushort)16);
                    writer.Write("data".ToCharArray());
                    writer.Write(samples.Length * 2);

                    foreach (var sample in samples)
                    {
                        writer.Write((short)(sample * short.MaxValue));
                    }
                }
                return memoryStream.ToArray();
            }
        }
    }
}