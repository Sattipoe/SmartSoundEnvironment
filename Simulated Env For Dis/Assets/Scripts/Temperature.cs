using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TemperatureSystem : MonoBehaviour
{
    public TextMeshProUGUI temperatureText; // Reference to the UI text element
    private AudioSource audioSource; // Reference to AudioSource component
    private bool songPlaying; // Flag to track if a song is currently playing
    public TemperatureZone temperatureZone;
    public bool inRange;
    private float currentTemperature;

    void Start()
    {
        // Find the Text component in the scene
        temperatureText = GameObject.FindWithTag("TemperatureText").GetComponent<TextMeshProUGUI>();
        // Ensure the temperature text is initialized with a default value
        temperatureText.text = "Current Temperature: 0°C";
        // Get the AudioSource component attached to the object
        audioSource = GetComponent<AudioSource>();
        inRange = false;
    }

    void Update()
    {
        // Update current temperature based on the box the player is in
        UpdateTemperature();
    }

    void UpdateTemperature()
    {
        // Find the box the player is currently in
        
        if (inRange == true)
        
        {
            // Get temperature parameters from the TemperatureZone component
            if (temperatureZone != null)
            {
                print("2");
                currentTemperature = CalculateTemperature(temperatureZone);
                temperatureText.text = "Current Temperature: " + currentTemperature.ToString("F1") + "°C";

                // Play the appropriate song based on temperature
            }
        }
    }

    void OnTriggerExit(Collider other)

    {
        if (other.tag == "Player" && inRange == true)
        {
            inRange = false;
            audioSource.Stop();
        }

    }

    void OnTriggerEnter(Collider other)

    {
        if (other.tag == "Player" && inRange == false)
        {
            inRange = true;
            PlaySong(currentTemperature, temperatureZone.coldSong, temperatureZone.hotSong);
        }

    }

    float CalculateTemperature(TemperatureZone temperatureZone)
    {
        // Simulate temperature fluctuations over time
        float temperatureChange = temperatureZone.temperatureChangeSpeed * Time.deltaTime * 0.1f; // Decrease the effect of temperatureChangeSpeed
        float currentTemperature = Random.Range(temperatureZone.minTemperature, temperatureZone.maxTemperature);
        currentTemperature += Random.Range(-temperatureChange, temperatureChange);
        currentTemperature = Mathf.Clamp(currentTemperature, temperatureZone.minTemperature, temperatureZone.maxTemperature);
        return currentTemperature;
    }


    void PlaySong(float currentTemperature, AudioClip coldSong, AudioClip hotSong)
    {
        print("Function called");
        // Stop any currently playing song
        audioSource.Stop();

        // Play the appropriate song based on temperature
        if (currentTemperature > 10)
        {
            audioSource.clip = hotSong;
            print("you have entered a warm zone");
        }
        else
        {
            audioSource.clip = coldSong;
        }
        audioSource.Play();
        songPlaying = true;
        print("you have entered a cold zone");
    }
}
