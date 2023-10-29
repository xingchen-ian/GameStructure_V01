using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Start,
    Playing,
    Paused,
    GameOver
}

public class GameStateController : MonoBehaviour
{
    public Text gameStateText;
    private GameState currentState;

    // Singleton instance
    private static GameStateController instance;

    public static GameStateController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameStateController>();
                if (instance == null)
                {
                    // If no instance exists in the scene, create a new GameObject with the GameStateController component
                    GameObject singletonObject = new GameObject("GameStateController");
                    instance = singletonObject.AddComponent<GameStateController>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Ensure there is only one instance of GameStateController
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        // Initialize the game
        currentState = GameState.Start;
        UpdateUI();
    }

    public void Update()
    {
        // Game state logic
        switch (currentState)
        {
            case GameState.Start:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartGame();
                }
                break;
            case GameState.Playing:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    PauseGame();
                }
                // Gameplay logic here
                break;
            case GameState.GameOver:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RestartGame();
                }
                break;
        }
    }

    public void StartGame()
    {
        currentState = GameState.Playing;
        UpdateUI();
        // Start gameplay logic, spawn enemies, etc.
    }

    public void PauseGame()
    {
        currentState = GameState.Paused;
        UpdateUI();
        // Pause gameplay logic, show pause menu, etc.
    }

    public void RestartGame()
    {
        currentState = GameState.Start;
        InitializeGame();
        // Reset game state, scores, and other variables
    }

    private void UpdateUI()
    {
        // Update UI to reflect the current game state
        gameStateText.text = "Game State: " + currentState.ToString();
    }
}
