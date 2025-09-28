// Import necessary namespaces (libraries) we need
using System; // Basic C# system functions
using UnityEngine; // Core Unity engine classes
using UnityEngine.InputSystem; // Unity's new Input System for handling controller input
using UnityEngine.InputSystem.XR; // Specific XR (VR/AR) input components
using UnityEngine.XR.Interaction.Toolkit.Interactors; // XR interactor components

/*
 * IMPORTANT: Assign this script to the controller GameObject that has the XRRayInteractor component
 * 
 * PURPOSE: This script handles input from VR controllers to enable/disable ray casting
 * FUNCTIONALITY: When user presses a button, the ray appears. When they release it, the ray disappears.
 * 
 * WHY WE NEED THIS: Without input management, the ray would always be on or always be off.
 *                   This gives the user control over when to show the interaction ray.
 */

public class VRInputManager : MonoBehaviour // Inherit from MonoBehaviour to make this a Unity component
{
    // SerializeField makes this private variable visible in Unity Inspector
    // This will reference the input action that activates the ray (like trigger button)
    [SerializeField] private InputActionReference activateAction;
    
    // Commented out for now - could be used for selection actions later
    //[SerializeField] private InputActionReference selectionAction;

    // Private reference to the XRRayInteractor component on this same GameObject
    private XRRayInteractor rayInteractor;

    // Awake() is called before Start(), used for internal initialization
    private void Awake()
    {
        // Get the XRRayInteractor component that's attached to this same GameObject
        // This will be null if no XRRayInteractor is found, so make sure to add one!
        rayInteractor = GetComponent<XRRayInteractor>();
    }
    // OnEnable() is called every time this GameObject becomes active
    private void OnEnable()
    {
        // Subscribe to the "performed" event - this happens when the button is pressed
        // ctx = context, contains information about the input action
        activateAction.action.performed += ctx =>
        {
            // When button is pressed, enable the ray interactor (turn on the ray)
            rayInteractor.enabled = true;
        };
        
        // Subscribe to the "canceled" event - this happens when the button is released
        activateAction.action.canceled += ctx =>
        {
            // When button is released, disable the ray interactor (turn off the ray)
            rayInteractor.enabled = false;
        };
    }
}
