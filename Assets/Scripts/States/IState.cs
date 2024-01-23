using UnityEngine;

public interface IState {
    public void Entry();
    public void Update();
    public void Exit();
}
