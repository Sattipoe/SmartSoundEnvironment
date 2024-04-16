using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public string Music;
    public AudioSource audioSource;
    private bool isPlaying = false;
    public SunLightRotation timeOfDay;
    public AudioSource audioSource2;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource2 = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        audioSource2.playOnAwake = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has a Rigidbody component
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Check if the object has a tag "Player" or any other specific tag you want
            if (other.CompareTag("Player"))
            {
                if (!isPlaying)
                {
                    if (timeOfDay.TimeOfDay == true)
                    {
                        audioSource.Stop();
                        audioSource2.Play();
                    }
                    else if (timeOfDay.TimeOfDay == false)
                    {
                        audioSource2.Stop();
                        audioSource.Play();
                    }

                    isPlaying = true; // Set isPlaying to true after starting the music
                }
                else
                {
                    audioSource.Stop();
                    audioSource2.Stop();
                    isPlaying = false; // Set isPlaying to false after stopping the sound
                }
            }
        }
    }
}
