using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public enum GameState { Start, Playing, YouWin, GameOver }
    public GameState currentState = GameState.Start;

    // ✅ Make sure to call base.Awake() so Singleton initializes properly
    protected override void Awake()
    {
        base.Awake(); // Registers Instance + DontDestroyOnLoad
    }

    private void Start()
    {
        // Only set Start state if not already in Start scene
        if (SceneManager.GetActiveScene().name != "Start")
        {
            ChangeState(GameState.Start);
        }
        else
        {
            currentState = GameState.Start;
            Debug.Log("Game started in Start scene.");
        }
    }

    public void ChangeState(GameState newState)
    {
        // Avoid repeating same state
        if (currentState == newState)
            return;

        currentState = newState;
        Debug.Log("Game state changed to: " + currentState);

        switch (newState)
        {
            case GameState.Start:
                SceneManager.LoadScene("Start");
                break;
            case GameState.Playing:
                SceneManager.LoadScene("Playing");
                break;
            case GameState.YouWin:
                SceneManager.LoadScene("YouWin");
                break;
            case GameState.GameOver:
                SceneManager.LoadScene("GameOver");
                break;
        }
    }

    public void StartGame() => ChangeState(GameState.Playing);
    public void WinGame() => ChangeState(GameState.YouWin);
    public void LoseGame() => ChangeState(GameState.GameOver);
}