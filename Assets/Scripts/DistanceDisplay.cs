using TMPro;
using UnityEngine;

public class DistanceDisplay : MonoBehaviour
{
    // Reference to the main camera
    private Camera mainCamera;
    private LODGroup lODGroup;

    // Reference to the text UI component on the cube
    private TextMeshProUGUI distanceText;

    void Start()
    {
        // Get the main camera in the scene
        mainCamera = Camera.main;

        // Get the TextMesh component attached to the cube
        distanceText = GetComponentInChildren<TextMeshProUGUI>();

        //Get the LODGroup
        lODGroup = GetComponent<LODGroup>();

        // Check if the TextMeshProUGUI component exists
        if (distanceText == null)
        {
            Debug.LogError("TextMesh component not found. Make sure it's attached to the cube prefab.");
        }
    }

    void Update()
    {
        // Calculate the distance from the cube to the main camera
        float distance = Vector3.Distance(transform.position, mainCamera.transform.position);

        if(distance > 60)
        {
            //when the cube is occluded
            distanceText.enabled = false;
        }
        else
        {
            //cube visible
            distanceText.enabled = true;
            // Update the text to display the distance
            distanceText.text = distance.ToString("F2"); // Display distance with 2 decimal places
        }

        
    }
}
