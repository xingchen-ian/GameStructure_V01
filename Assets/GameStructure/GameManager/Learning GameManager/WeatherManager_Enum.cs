using TMPro;
using UnityEngine;

// Version 1: Enum
public class WeatherManager_Enum : MonoBehaviour
{
    // Define possible weathers, declare a enum including all options;
    public enum WeatherType { Sunny, Rain, Wind, Drizzle }
    
    /*
     * An enum is a special "class" that represents a group of constants (unchangeable/read-only variables).
     * To create an enum, use the enum keyword (instead of class or interface), and separate the enum items with a comma:
     * https://www.w3schools.com/cs/cs_enums.php
     * When a enum is created you have a blueprint prepared there.  It is not a data occupying space in your memory card.  You need to declare a variable of this type of data.
     */
    
    public WeatherType currentWeather;

    //public Text weatherText; // Reference to UI Text
    public TMP_Text weatherText;

    void Update()
    {
        // Change weather based on key press
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentWeather = WeatherType.Sunny;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentWeather = WeatherType.Rain;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentWeather = WeatherType.Wind;
        if (Input.GetKeyDown(KeyCode.Alpha4)) currentWeather = WeatherType.Drizzle;

        // Update UI
        if (weatherText != null)
            weatherText.text = "Weather: " + currentWeather;
    }
}













