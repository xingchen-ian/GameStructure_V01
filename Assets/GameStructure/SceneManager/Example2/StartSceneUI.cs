using UnityEngine;

public class StartSceneUI : MonoBehaviour
{
    // This will be called by a UI Button OnClick event
    public void OnStartButtonPressed()
    {
        GameManager.Instance.StartGame();
    }
}


/*
   ┌─────────────────────────────┐
   │        Singleton<T>         │
   │-----------------------------│
   │ + Instance : T              │
   │ + Awake()                   │
   │ + OnDestroy()               │
   └──────────────▲──────────────┘
                  │ inherits
                  │
   ┌─────────────────────────────┐
   │        GameManager          │
   │-----------------------------│
   │ + currentState : GameState  │
   │ + ChangeState()             │
   │ + StartGame()               │
   │ + WinGame()                 │
   │ + LoseGame()                │
   └──────────────▲──────────────┘
                  │ referenced by
                  │
         ┌─────────────────────────────┐
         │         Scenes              │
         │-----------------------------│
         │  Start Scene   → calls      │
         │   GameManager.StartGame()   │
         │                             │
         │  Playing Scene → triggers   │
         │   GameManager.WinGame()     │
         │                             │
         │  YouWin Scene  → restarts   │
         │   GameManager.StartGame()   │
         │                             │
         │  GameOver Scene → restarts  │
         │   GameManager.StartGame()   │
         └─────────────────────────────┘
         
///============= 
   
   ## 🧭 Step-by-Step Explanation of the GameManager Structure
   
  
  
   ########### Step 1 — The Foundation: `Singleton<T>` #############
   
   * The `Singleton<T>` class is a template (generic) base class.
   * Its job: ensure that only one instance of any manager (like `GameManager`) exists in the game.
   
     ```
     public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
     {
         public static T Instance { get; private set; }
   
         protected virtual void Awake()
         {
             if (Instance != null && Instance != this)
                 Destroy(gameObject);
             else
                 Instance = this as T;
         }
     }
     ```
   
   🧩In the diagram:
   
   ```
   ┌─────────────────────────────┐
   │        Singleton<T>         │
   │-----------------------------│
   │ + Instance : T              │
   │ + Awake()                   │
   │ + OnDestroy()               │
   └──────────────▲──────────────┘
   ```
   
   > Think of `Singleton<T>` as a reusable *blueprint* that can turn any manager into a “one and only” object in the game.
   






   
   ############# Step 2 — The Core Controller: `GameManager` ##############
   
   * `GameManager` **inherits** from `Singleton<GameManager>`:
   
     ```
     public class GameManager : Singleton<GameManager>
     ```
   * That means it automatically gets the **singleton behavior** — only one instance will ever exist.
   * It also introduces the **game logic**:
   
     * `GameState` (enum): defines the current phase (Start, Playing, YouWin, GameOver)
     * `ChangeState()`: switches the game state and loads the correct scene
     * `StartGame()`, `WinGame()`, `LoseGame()`: helper functions for transitions
   
   🧩 **In the diagram:**
   
   ```
   ┌─────────────────────────────┐
   │        GameManager          │
   │-----------------------------│
   │ + currentState : GameState  │
   │ + ChangeState()             │
   │ + StartGame()               │
   │ + WinGame()                 │
   │ + LoseGame()                │
   └──────────────▲──────────────┘
                  │ referenced by
                  │
   ```
   
   > The **GameManager** is the central brain — it keeps track of what state the game is in and tells Unity which scene to load.
   
   ---
   
   
   
   
   
   
   
   ############ Step 3 — The Scenes: Using the Manager  ################
   
   Each **scene** (Start, Playing, YouWin, GameOver) doesn’t manage the game flow itself — it just **talks to** the `GameManager`.
   
   🧩 In the diagram:
   
   ```
         ┌─────────────────────────────┐
         │         Scenes              │
         │-----------------------------│
         │  Start Scene   → calls      │
         │   GameManager.StartGame()   │
         │                             │
         │  Playing Scene → triggers   │
         │   GameManager.WinGame()     │
         │                             │
         │  YouWin Scene  → restarts   │
         │   GameManager.StartGame()   │
         │                             │
         │  GameOver Scene → restarts  │
         │   GameManager.StartGame()   │
         └─────────────────────────────┘
   ```
   
   🧠 **Flow in action:**
   
   1. **Start Scene**
   
      * The player presses “Start.”
      * Code calls:
   
        ```csharp
        GameManager.Instance.StartGame();
        ```
      * Unity loads the **Playing Scene**.
   
   2. **Playing Scene**
   
      * Player plays, health and countdown run.
      * When countdown finishes →
   
        ```csharp
        GameManager.Instance.WinGame();
        ```
   
        → loads **YouWin Scene**.
      * If health hits 0 →
   
        ```csharp
        GameManager.Instance.LoseGame();
        ```
   
        → loads **GameOver Scene**.
   
   3. **YouWin / GameOver Scene**
   
      * A button triggers
   
        ```csharp
        GameManager.Instance.StartGame();
        ```
   
        → loads **Start Scene** again.
   
   ---
   
   
   
   
   
   
   ############# Step 4 — The Big Picture  #################
   
   ✅ **`Singleton<T>`**
   → ensures only one GameManager exists (no duplicates).
   
   ✅ **`GameManager`**
   → holds and controls game states + scene transitions.
   
   ✅ **Scenes**
   → communicate with GameManager to change what happens next.
   
   ---
   
   ### **🪄 Optional Teaching Tip**
   
   You can visualize this with an **arrow-based loop** in slides:
   
   ```
   [Start Scene]
        ↓ (StartGame)
   [Playing Scene]
        ↓ (WinGame)
   [YouWin Scene]
        ↘︎ (StartGame)
        ↓
   [GameOver Scene]
        ↘︎ (StartGame)
        ↓
   [Start Scene]
   ```
   
   This helps students see how **GameManager orchestrates the loop** between scenes — while keeping all logic centralized and easy to maintain.
   
   ---
   
   Would you like me to make a **printable Markdown or PDF handout** version of this step-by-step guide (with the ASCII diagram and arrows formatted nicely for students)?
   


///=============
         
   
*/