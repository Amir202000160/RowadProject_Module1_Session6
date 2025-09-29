// Import necessary namespaces (libraries) we need
using Unity.VisualScripting; // Unity's visual scripting system
using UnityEngine; // Core Unity engine classes
using UnityEngine.XR.Interaction.Toolkit; // XR interaction system for VR/AR
using UnityEngine.XR.Interaction.Toolkit.Interactors; // XR interactor components 
using UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals; // Visual components for XR interactions


/*
 * Hello developers!!!!!!!!
 * This script sets up XRRayInteractors on the left and right controllers if they don't already have one.
 * 
 * PURPOSE: Automatically adds ray casting ability to VR controllers
 * USAGE: Attach this script to an empty GameObject in your scene and assign the left and right controllers
 *        in the inspector.
 * 
 * WHY WE NEED THIS: VR controllers need ray interactors to point at and interact with objects in 3D space
 */

public class SetupRayInteractorsPart2 : MonoBehaviour // Inherit from MonoBehaviour to make this a Unity component
{
    // SerializeField makes these private variables visible in Unity Inspector for easy assignment
    // assign the left and right controllers in the inspector
    
    [SerializeField] private GameObject leftController; // Reference to the left VR controller GameObject
    [SerializeField] private GameObject rightController; // Reference to the right VR controller GameObject
    
    
    
    // Start() is called once before the first frame update
    void Start()
    {
        // Check if left controller already has XRRayInteractor component
        // TryGetComponent returns true if component exists, false if it doesn't
        if (!leftController.TryGetComponent<XRRayInteractor>(out var _))
        {
            // Add XRRayInteractor component to left controller if it doesn't have one
            XRRayInteractor leftRay = leftController.gameObject.AddComponent<XRRayInteractor>();
            // Configure the ray's properties (distance, layers, etc.)
            ConfigureRayInteractor(leftRay);
        }
        
        // Do the same check and setup for right controller
        if (!rightController.TryGetComponent<XRRayInteractor>(out var _))
        {
            // Add XRRayInteractor component to right controller if it doesn't have one
            XRRayInteractor rightRay = rightController.gameObject.AddComponent<XRRayInteractor>();
            // Configure the ray's properties
            ConfigureRayInteractor(rightRay);
        }
    }

    // Private method to configure the properties of a ray interactor
    private void ConfigureRayInteractor(XRRayInteractor ray)
    {
        // Set how far the ray can reach (20 units in this case)
        ray.maxRaycastDistance = 20.0f;
        
        // Set where the ray starts from (the controller's position)
        ray.rayOriginTransform = ray.transform;
        
        // Set which interaction layer this ray can interact with
        // Only objects on the "Lamp" layer will respond to this ray
        ray.interactionLayers = InteractionLayerMask.GetMask("Lamp");

        /*
         * COMMENTED OUT CODE - This would add visual representation of the ray
         * Uncomment this section if you want to see the ray as a line in VR
         * 
        XRInteractorLineVisual lineVisual = ray.gameObject.AddComponent<XRInteractorLineVisual>();
        if (lineVisual != null)
        {
            lineVisual.lineWidth = 0.02f; // Width of the ray line
            lineVisual.invalidColorGradient = new Gradient(); // Color gradient for when ray can't interact
            meshRenderer = lineVisual.gameObject.AddComponent<MeshRenderer>();
            meshRenderer.material = rayMaterial; // Apply the material to make ray visible
            meshFilter = lineVisual.gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = lineVisual.GetComponent<MeshFilter>().mesh;
        }
        */
    }
}
