using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Version 4: Full Game with Methods
public class GameManager_Methods : MonoBehaviour
{
    public static GameManager_Methods Instance { get; private set; }

    public enum WeatherType { Sunny, Rain, Wind, Drizzle }
    public WeatherType currentWeather;
    public int playerHealth = 10;

    public TMP_Text weatherText;
    public TMP_Text descriptionText;
    public TMP_Text healthText;
    public TMP_Text gameOverText;

    private float timer = 0f;
    public float effectInterval = 1f; // Apply effect every 1 second

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else { Instance = this; DontDestroyOnLoad(gameObject); }

        if (gameOverText != null) gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Change weather
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetWeather(WeatherType.Sunny);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetWeather(WeatherType.Rain);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SetWeather(WeatherType.Wind);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SetWeather(WeatherType.Drizzle);

        // Apply weather effect every interval
        timer += Time.deltaTime;
        if (timer >= effectInterval)
        {
            timer = 0f;
            ApplyWeatherEffect();
        }

        // Check if player is alive
        if (!IsPlayerAlive() && gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        // Update UI
        if (weatherText != null) weatherText.text = "Weather: " + currentWeather;
        if (healthText != null) healthText.text = "Health: " + playerHealth;
    }

    // Public method to set weather
    public void SetWeather(WeatherType type)
    {
        currentWeather = type;
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
    }

    // Apply weather effect on player
    public void ApplyWeatherEffect()
    {
        switch (currentWeather)
        {
            case WeatherType.Sunny: playerHealth += 1; break;
            case WeatherType.Rain: playerHealth -= 2; break;
            case WeatherType.Wind: playerHealth -= 2; break;
            case WeatherType.Drizzle: playerHealth += 1; break;
        }
    }

    // Check if player is alive
    public bool IsPlayerAlive() => playerHealth > 0;
}
