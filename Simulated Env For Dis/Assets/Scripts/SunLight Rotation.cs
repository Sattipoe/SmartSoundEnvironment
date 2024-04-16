using UnityEngine;

public class SunLightRotation : MonoBehaviour
{
    public float rotationSpeed = 1.0f;

    void Update()
    {
        // Rotate the sun around the Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public bool TimeOfDay
    {
        get
        {
            // Get the current rotation of the sun
            float currentRotation = transform.rotation.eulerAngles.y;

            // Check if the sun's rotation is between 186 and 360 degrees
            if (currentRotation >= 186 && currentRotation <= 360)
            {
                return true; // Return true if the condition is met
            }
            else
            {
                return false; // Otherwise, return false
            }
        }
    }
}
