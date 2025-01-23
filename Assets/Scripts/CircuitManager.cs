using System.Collections;
using UnityEngine;

public class CircuitManager : MonoBehaviour
{
    public AudioSource audio;
    public Material OnSwitchMaterial;
    public Material OffSwitchMaterial;
    public Material OnBulbMaterial;
    public Material OffBulbMaterial;
    public Renderer switchRenderer;
    public Renderer bulbRenderer;
    public Renderer[] cylinderRenderers; // Array of cylinder renderers, assigned in order
    public bool On;
    public Color sparkColor = Color.cyan; // Color for electric spark effect
    public float glowIntensity = 2f; // Intensity of the glow effect
    public float glowSpeed = 5f; // Speed of the pulsing effect

    private Camera arCamera;

    void Start()
    {
        // Cache the AR camera reference
        arCamera = Camera.main;

        // Ensure all cylinders and the bulb are off initially
        foreach (Renderer cylinder in cylinderRenderers)
        {
            SetCylinderColor(cylinder, Color.gray); // Default off color
        }
        bulbRenderer.material = OffBulbMaterial;
    }

    void Update()
    {
        // Handle touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Ended)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Check if we hit this object's collider
                    if (hit.collider.gameObject == gameObject)
                    {
                        ChangeMaterial();
                        PlaySound();

                        // Start the sequence to light up the cylinders and the bulb
                        if (On)
                        {
                            StartCoroutine(LightUpSequence());
                        }
                        else
                        {
                            ResetCircuit();
                        }
                    }
                }
            }
        }
    }

    void PlaySound()
    {
        if (audio != null)
        {
            audio.Play();
        }
    }

    void ChangeMaterial()
    {
        // Toggle the state first
        On = !On;

        Debug.Log($"Switch state changed to: {On}");

        // Apply materials based on the current state
        if (On)
        {
            switchRenderer.material = OnSwitchMaterial;
        }
        else
        {
            switchRenderer.material = OffSwitchMaterial;
        }
    }

    IEnumerator LightUpSequence()
    {
        // Light up each cylinder in order with a glowing effect
        foreach (Renderer cylinder in cylinderRenderers)
        {
            StartCoroutine(GlowEffect(cylinder)); // Start glow effect for this cylinder
            yield return new WaitForSeconds(0.5f); // Delay between lighting each cylinder
        }

        // Finally, light up the bulb
        bulbRenderer.material = OnBulbMaterial;

        // Start the pulsating spark effect for the whole circuit
        StartCoroutine(CircuitSparkEffect());
    }

    void ResetCircuit()
    {
        // Turn off all cylinders and the bulb
        foreach (Renderer cylinder in cylinderRenderers)
        {
            SetCylinderColor(cylinder, Color.gray); // Reset to default off color
        }
        bulbRenderer.material = OffBulbMaterial;
    }

    void SetCylinderColor(Renderer cylinder, Color color)
    {
        // Update the cylinder's material color
        cylinder.material.color = color;
    }

    IEnumerator GlowEffect(Renderer cylinder)
    {
        // Pulsate the cylinder's color to simulate a glowing effect
        float elapsedTime = 0f;
        float duration = 1.5f; // Duration of the glow cycle

        while (On)
        {
            elapsedTime += Time.deltaTime * glowSpeed;
            float intensity = Mathf.PingPong(elapsedTime, glowIntensity);
            cylinder.material.color = sparkColor * intensity; // Adjust color intensity
            yield return null;
        }

        // Reset to off color when turned off
        cylinder.material.color = Color.gray;
    }

    IEnumerator CircuitSparkEffect()
    {
        // Pulsate all cylinders and bulb with spark effect
        float elapsedTime = 0f;

        while (On)
        {
            elapsedTime += Time.deltaTime * glowSpeed;
            float intensity = Mathf.PingPong(elapsedTime, glowIntensity);

            // Apply pulsating spark effect to all cylinders
            foreach (Renderer cylinder in cylinderRenderers)
            {
                cylinder.material.color = sparkColor * intensity;
            }

            // Apply spark effect to the bulb
            bulbRenderer.material.color = sparkColor * intensity;

            yield return null;
        }

        // Reset all when turned off
        foreach (Renderer cylinder in cylinderRenderers)
        {
            cylinder.material.color = Color.gray;
        }
        bulbRenderer.material = OffBulbMaterial;
    }
}
