// Import necessary namespaces (libraries) that contain classes we need
using System; // Basic C# system functions
using UnityEngine; // Core Unity engine classes like MonoBehaviour, GameObject, etc.
using UnityEngine.XR.Interaction.Toolkit; // XR interaction system for VR/AR
using UnityEngine.XR.Interaction.Toolkit.Interactables; // Specific XR interactable components

/*
 * This script goes on the target objects you want to interact with in VR
 * It handles what happens when a VR controller points at or selects this object
 */
public class SimpleTarget : MonoBehaviour // Inherit from MonoBehaviour to make this a Unity component
{
    // Private variables - only this class can access them
    private XRSimpleInteractable interactable; // Reference to the XR component that makes this object interactable
    private MeshRenderer meshRenderer; // Component that renders (draws) the 3D mesh on screen
    
    // SerializeField makes private variables visible in Unity Inspector for easy assignment
    [SerializeField] private Material defaultMaterial; // The normal material when not being hovered
    [SerializeField] private Material HittMaterial; // The material to show when controller hovers over this object

    // Awake() is called before Start(), used for internal initialization
    void Awake() // Or Start()
    {
        // Get the MeshRenderer component attached to this same GameObject
        meshRenderer = GetComponent<MeshRenderer>();
        
        // Get the XRSimpleInteractable component that makes this object interactable in VR
        interactable = GetComponent<XRSimpleInteractable>();
    }

    // OnEnable() is called every time this GameObject becomes active
    void OnEnable()
    {
        // Add listeners (event handlers) when the object is enabled
        // When controller hovers over this object, call OnHoverEnter method
        interactable.hoverEntered.AddListener(OnHoverEnter);
        
        // When controller stops hovering over this object, call OnHoverExit method
        interactable.hoverExited.AddListener(OnHoverExit);
    }

    // Start() is called once before the first frame update
    void Start()
    {
        // Set the initial material to the default (non-hovered) state
        meshRenderer.material = defaultMaterial;
        
        // Set which interaction layer this object belongs to
        // "Lamp" is a custom layer name - objects must be on same layer to interact
        interactable.interactionLayers = InteractionLayerMask.GetMask("Lamp");
    }

    // This method is called when a VR controller starts hovering over this object
    void OnHoverEnter(HoverEnterEventArgs args)
    {
        // Log debug information to console - useful for testing
        // args.interactorObject = the controller that is hovering
        // args.interactableObject = this object being hovered over
        Debug.Log($"Hover Enter: {args.interactorObject.transform.name} hovered over {args.interactableObject.transform.name}");
        
        // Change the material to the "hit" material to show visual feedback
        meshRenderer.material = HittMaterial;
    }

    // This method is called when a VR controller stops hovering over this object
    void OnHoverExit(HoverExitEventArgs args)
    {
        // Log debug information to console
        Debug.Log($"Hover Exit: {args.interactorObject.transform.name} stopped hovering over {args.interactableObject.transform.name}");
        
        // Change the material back to the default (normal) state
        meshRenderer.material = defaultMaterial;
    }

    // OnDisable() is called when this GameObject becomes inactive
    void OnDisable()
    {
        // VERY IMPORTANT: Remove listeners when the object is disabled to prevent memory leaks
        // If we don't do this, Unity might try to call methods on destroyed objects
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
        interactable.hoverExited.RemoveListener(OnHoverExit);
    }
}