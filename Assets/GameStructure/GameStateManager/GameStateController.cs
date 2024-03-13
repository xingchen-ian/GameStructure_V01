using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    State00,
    State01,
    State02,
    State03,
    State04
}

public class GameStateController : MonoBehaviour
{
    public Text gameStateText;
    private GameState _currentState;

    // ===== Singleton instance ===== //
    private static GameStateController _instance;
    public static GameStateController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameStateController>();
                if (_instance == null)
                {
                    // If no instance exists in the scene, create a new GameObject with the GameStateController component
                    GameObject singletonObject = new GameObject("GameStateController");
                    _instance = singletonObject.AddComponent<GameStateController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Ensure there is only one instance of GameStateController
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // ===== the end of singleton implementation ===== //
    
    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        // Initialize the game
        _currentState = GameState.State00;
        UpdateUI();
    }

    public void Update()
    {
        // Game state logic
        switch (_currentState)
        {
            case GameState.State01:
                // Example: Press space to start the game
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartGame();
                }
                // end of this example
                
                // ====================================
                
                // Example: Do something else to change the game state
                // ...
                // end of this example
                break;
            
            case GameState.State02:
                // Example: Press P to pause the game
                if (Input.GetKeyDown(KeyCode.P))
                {
                    PauseGame();
                }
                // end of this example
                
                // ====================================
                
                // Example: Do something else to change the game state
                // ...
                // end of this example
                break;
            
            case GameState.State03:
                // Example: Do something to change the game state
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RestartGame();
                }
                // end of this example
                
                // ====================================
                
                // Example: Do something else to change the game state
                // ...
                // end of this example
                break;
            
        }
    }

    // Game state functions
    private void StartGame()
    {
        _currentState = GameState.State01;
        UpdateUI();
        // Start gameplay logic, spawn enemies, etc.
    }

    private void PauseGame()
    {
        _currentState = GameState.State02;
        UpdateUI();
        // Pause gameplay logic, show pause menu, etc.
    }

    private void RestartGame()
    {
        _currentState = GameState.State03;
        InitializeGame();
        // Reset game state, scores, and other variables
    }

    private void UpdateUI()
    {
        // Update UI to reflect the current game state
        gameStateText.text = "Game State: " + _currentState.ToString();
    }
}
