using UnityEngine;

public class YouWinUI : MonoBehaviour
{
    public void OnRestartButtonPressed()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.Start);
    }
}