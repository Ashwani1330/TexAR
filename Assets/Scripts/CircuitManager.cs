using UnityEngine;

public class CircuitManager : MonoBehaviour
{
    public Material OnSwitchMaterial; // The new material to assign to the object
    public Material OnBulbMaterial;
    public Material OffSwitchMaterial;
    public Material OffBulbMaterial;
    public Renderer switchRenderer;
    public Renderer bulbRenderer;
    public bool On;
    
    void Update()
    {
        // Detect touches or mouse clicks
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch
            if (touch.phase == TouchPhase.Began) // Check if the touch just started
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) // Perform a raycast to detect objects
                {
                    if (hit.transform == transform) // Check if the switch was touched
                    {
                        ChangeMaterial(); // Update materials based on the toggle
                    }
                }
            }
        }
    }

    void OnMouseDown()
    {
        ChangeMaterial(); 
    }

    void ChangeMaterial()
    {
        Debug.Log("Clicked");
        // Change materials based on the On state
        if (On)
        {
            bulbRenderer.material = OnBulbMaterial;
            switchRenderer.material = OnSwitchMaterial;
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else
        {
            bulbRenderer.material = OffBulbMaterial;
            switchRenderer.material = OffSwitchMaterial;
            transform.eulerAngles = new Vector3(0, 180, 90);
        }
        On = !On;
    }
}
