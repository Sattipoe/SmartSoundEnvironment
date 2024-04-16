using UnityEngine;

public class TemperatureZone : MonoBehaviour
{
    public float minTemperature = 0f;
    public float maxTemperature = 20f;
    public float temperatureChangeSpeed = 1f;
    public AudioClip coldSong; // Define coldSong field
    public AudioClip hotSong;  // Define hotSong field
}
