using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Version 3: Singleton GameManager
public class GameManager_Singleton : MonoBehaviour
{
    // Singleton instance
    public static GameManager_Singleton Instance { get; private set; }

    public enum WeatherType { Sunny, Rain, Wind, Drizzle }
    public WeatherType currentWeather;
    public int playerHealth = 100;

    public TMP_Text weatherText;
    public TMP_Text descriptionText;
    public TMP_Text healthText;

    private void Awake()
    {
        // Ensure single instance
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        // Change weather
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentWeather = WeatherType.Sunny;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentWeather = WeatherType.Rain;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentWeather = WeatherType.Wind;
        if (Input.GetKeyDown(KeyCode.Alpha4)) currentWeather = WeatherType.Drizzle;

        // Update UI
        if (weatherText != null) weatherText.text = "Weather: " + currentWeather;
        if (descriptionText != null)
        {
            switch (currentWeather)
            {
                case WeatherType.Sunny: descriptionText.text = "Sunny: Life slowly increases"; break;
                case WeatherType.Rain: descriptionText.text = "Rain: Life decreases"; break;
                case WeatherType.Wind: descriptionText.text = "Wind: Life decreases"; break;
                case WeatherType.Drizzle: descriptionText.text = "Drizzle: Life increases"; break;
            }
        }
        if (healthText != null) healthText.text = "Health: " + playerHealth;
    }
}