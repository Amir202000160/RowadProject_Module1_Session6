using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit.Interactors;




/* assgin this script to the controller with the XRRayInteractor component */

public class VRInputManager : MonoBehaviour
{

    [SerializeField] private InputActionReference activateAction;
   //[SerializeField] private InputActionReference selectionAction;

    private XRRayInteractor rayInteractor;

    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
       

    }
    private void OnEnable()
    {
       activateAction.action.performed += ctx =>
        {
            rayInteractor.enabled = true;
        };
        activateAction.action.canceled += ctx =>
        {
            rayInteractor.enabled = false;
        };

    }

}
