using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class GamePlayController : MonoBehaviour
{
    [Header("Gameplay Settings")]
    public int health = 10;
    public float countdownTime = 15f;

    [Header("UI References")]
    public TextMeshProUGUI healthText;     // Assign in Inspector
    public TextMeshProUGUI countdownText;  // Assign in Inspector

    private float countdown;
    private float healthTimer = 0f; // Used for timing health reduction

    private void Start()
    {
        countdown = countdownTime;
        UpdateUI();
    }

    private void Update()
    {
        // Decrease countdown by real time
        countdown -= Time.deltaTime;

        // Reduce health every second
        healthTimer += Time.deltaTime;
        if (healthTimer >= 1f)
        {
            health -= 1;
            healthTimer = 0f;
        }

        // Player can increase health by pressing space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health += 1;
        }

        // Update UI every frame
        UpdateUI();

        // Check win / lose conditions
        if (health <= 0)
        {
            GameManager.Instance.LoseGame();
        }

        if (countdown <= 0)
        {
            GameManager.Instance.WinGame();
        }
    }

    private void UpdateUI()
    {
        // Update text content
        if (healthText != null)
            healthText.text = "Health: " + Mathf.Max(health, 0);

        if (countdownText != null)
            countdownText.text = "Time: " + Mathf.Ceil(countdown);
    }
}