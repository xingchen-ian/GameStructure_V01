using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    // ===== Singleton instance ===== //
    private static SaveLoadManager instance;
    public static SaveLoadManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SaveLoadManager>();
                if (instance == null)
                {
                    // If no instance exists in the scene, create a new GameObject with the SaveLoadManager component
                    GameObject singletonObject = new GameObject("SaveLoadManager");
                    instance = singletonObject.AddComponent<SaveLoadManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Ensure there is only one instance of SaveLoadManager
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    // ===== the end of singleton implementation ===== //

    // Save and load functions for each variable you want to save/load
    public void SaveScore(int score)
    {
        // Save the player's score to PlayerPrefs
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();
    }

    public int LoadScore()
    {
        // Load the player's score from PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            return PlayerPrefs.GetInt("PlayerScore");
        }
        return 0; // Default score if no saved score exists
    }
    
    public void SaveName(string name)
    {
        // Save the player's name to PlayerPrefs
        PlayerPrefs.SetString("PlayerName", name);
        PlayerPrefs.Save();
    }
    
    public string LoadName()
    {
        // Load the player's name from PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            return PlayerPrefs.GetString("PlayerName");
        }
        return ""; // Default name if no saved name exists
    }
    
    public void SaveLevel(int level)
    {
        // Save the player's level to PlayerPrefs
        PlayerPrefs.SetInt("PlayerLevel", level);
        PlayerPrefs.Save();
    }
    
    public int LoadLevel()
    {
        // Load the player's level from PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            return PlayerPrefs.GetInt("PlayerLevel");
        }
        return 0; // Default level if no saved level exists
    }
    
    public void SaveHealth(int health)
    {
        // Save the player's health to PlayerPrefs
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.Save();
    }
    
    public int LoadHealth()
    {
        // Load the player's health from PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerHealth"))
        {
            return PlayerPrefs.GetInt("PlayerHealth");
        }
        return 0; // Default health if no saved health exists
    }
    
    // Add more save/load functions for more variables here...
}