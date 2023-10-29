using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    // Singleton instance
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
}