// Import necessary namespaces (libraries) we need
using System; // Basic C# system functions
using Unity.VisualScripting;
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

public class VRInputManagerPart2 : MonoBehaviour // Inherit from MonoBehaviour to make this a Unity component
{
    // SerializeField makes this private variable visible in Unity Inspector
    // This will reference the input action that activates the ray (like trigger button)
    [SerializeField] private InputActionReference activateAction;

    // Commented out for now - could be used for selection actions later
    //[SerializeField] private InputActionReference selectionAction;

    // Private reference to the XRRayInteractor component on this same GameObject
    [SerializeField] private SimpleTargetPart2 switchLamb;
    private bool isLambOn;
    [SerializeField] private MeshRenderer Lamb;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material HittMaterial;

    // Awake() is called before Start(), used for internal initialization
    private void Awake()
    {
        // Get the XRRayInteractor component that's attached to this same GameObject
        // This will be null if no XRRayInteractor is found, so make sure to add one!
        Lamb = GetComponent<MeshRenderer>();
        isLambOn = false;
        
    
    }
    // OnEnable() is called every time this GameObject becomes active
    private void OnEnable()
    {
        // Subscribe to the "performed" event - this happens when the button is pressed
        // ctx = context, contains information about the input action
        activateAction.action.performed += ctx => //on button press
        {
            if (switchLamb.isLambOn)
            { if (!isLambOn)
                {
                    Lamb.material = HittMaterial;
                    isLambOn = true;
                }
                else if(isLambOn)
                {
                    Lamb.material = defaultMaterial;
                    isLambOn = false;
                }
            
            }
            

        };
        
    
    }
}
