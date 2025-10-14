using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Version 2: Switch
public class WeatherManager_Switch : MonoBehaviour
{
    public enum WeatherType { Sunny, Rain, Wind, Drizzle }
    public WeatherType currentWeather;

    public TMP_Text weatherText;
    public TMP_Text descriptionText; // Display weather effect

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentWeather = WeatherType.Sunny;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentWeather = WeatherType.Rain;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentWeather = WeatherType.Wind;
        if (Input.GetKeyDown(KeyCode.Alpha4)) currentWeather = WeatherType.Drizzle;

        // Update UI
        if (weatherText != null)
            weatherText.text = "Weather: " + currentWeather;

        if (descriptionText != null)
        {
            // Switch statement for weather effect
            switch (currentWeather)
            {
                case WeatherType.Sunny:
                    descriptionText.text = "Sunny: Life slowly increases";
                    break;
                case WeatherType.Rain:
                    descriptionText.text = "Rain: Life decreases";
                    break;
                case WeatherType.Wind:
                    descriptionText.text = "Wind: Life decreases";
                    break;
                case WeatherType.Drizzle:
                    descriptionText.text = "Drizzle: Life increases";
                    break;
            }
        }
    }
}