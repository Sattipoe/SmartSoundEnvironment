using UnityEngine;

public class Rain : MonoBehaviour
{
    public ParticleSystem rainParticle; // Reference to the rain particle system
    public AudioSource rainMusic; // Reference to the rain music
    private bool isRaining = false; // Flag to track if it's raining
    private AudioSource[] allAudioSources; // Array to store all AudioSources in the scene

    public bool IsRaining
    {
        get { return isRaining; }
    }

    void Start()
    {
        // Get all AudioSources in the scene
        allAudioSources = FindObjectsOfType<AudioSource>();

        // Disable rain and rain music initially
        rainParticle.Stop();
        rainMusic.Stop();

        // Enable all AudioSources initially
        EnableAllAudioSources(true);
    }

    void Update()
    {
        // Toggle rain and change music
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleRain();
        }
    }

    void ToggleRain()
    {
        if (isRaining)
        {
            // Stop rain and rain music
            rainParticle.Stop();
            rainMusic.Stop();
            isRaining = false;

            // Enable all AudioSources
            EnableAllAudioSources(true);
        }
        else
        {
            // Play rain particle and rain music
            rainParticle.Play();
            rainMusic.Play();
            isRaining = true;

            // Disable all AudioSources except rain music
            EnableAllAudioSources(false, rainMusic);
        }
    }


    void EnableAllAudioSources(bool enable, AudioSource excludeSource = null)
    {
        // Enable or disable all AudioSources in the scene except the excluded one
        foreach (AudioSource source in allAudioSources)
        {
            if (source != excludeSource)
            {
                source.enabled = enable;
            }
        }
    }
}
