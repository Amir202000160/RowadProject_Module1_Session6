using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals;


/*
Hello developers!!!!!!!!
This script sets up XRRayInteractors on the left and right controllers if they don't already have one.
Attach this script to an empty GameObject in your scene and assign the left and right controllers
in the inspector.
*/

public class SetupRayInteractors : MonoBehaviour
{
    // assign the left and right controllers in the inspector
    
    [SerializeField] private GameObject leftController;
    [SerializeField] private GameObject rightController;
    [SerializeField] private Material rayMaterial; // Material for the ray
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
  
    
    void Start()
    {
        if (!leftController.TryGetComponent<XRRayInteractor>(out var _))
        {
            XRRayInteractor leftRay = leftController.gameObject.AddComponent<XRRayInteractor>();// Add XRRayInteractor if not present
            leftRay.enabled=false; // Start with the ray disabled
            ConfigureRayInteractor(leftRay);
        }
        if (!rightController.TryGetComponent<XRRayInteractor>(out var _))
        {
            XRRayInteractor rightRay = rightController.gameObject.AddComponent<XRRayInteractor>();// Add XRRayInteractor if not present
            rightRay.enabled=false; // Start with the ray disabled
            ConfigureRayInteractor(rightRay);
        }

    }

    private void ConfigureRayInteractor(XRRayInteractor ray)
    {
        ray.maxRaycastDistance = 20.0f; // How far the ray reaches
        ray.rayOriginTransform = ray.transform;// Where the ray starts from

        ray.interactionLayers = InteractionLayerMask.GetMask("Target"); // Layers the ray can interact with

        XRInteractorLineVisual lineVisual = ray.gameObject.AddComponent<XRInteractorLineVisual>();
        if (lineVisual != null)
        {
            lineVisual.lineWidth = 0.02f; // Width of the ray
            lineVisual.invalidColorGradient = new Gradient(); //Configure Gradient for invalid color
            meshRenderer = lineVisual.gameObject.AddComponent<MeshRenderer>();
            meshRenderer.material = rayMaterial; // Assign the material to the MeshRenderer
            meshFilter = lineVisual.gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = lineVisual.GetComponent<MeshFilter>().mesh;
    
           
        }


    }
}
