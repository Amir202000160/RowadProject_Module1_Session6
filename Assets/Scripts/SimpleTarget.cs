using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


/*this script goes on the target objects you want to interact with*/
public class SimpleTarget : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    private MeshRenderer meshRenderer; 
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material HittMaterial;
     
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
       /* interactable.selectEntered.AddListener(enter => OnSelectEnter());
        interactable.selectExited.AddListener(exit => OnSelectExit());*/
    }

   

    void OnHoverEnter(HoverEnterEventArgs args)
    {
       
        Debug.Log($"Hover:{args.interactableObject.transform.name}");
        Debug.Log($"{args.interactorObject.transform.name}");
        meshRenderer.material = HittMaterial;
    }
    void OnHoverExit(HoverExitEventArgs args)
    {
       
        Debug.Log($"Exit:{args.interactableObject.transform.name}");
        meshRenderer.material = defaultMaterial;
    }

    /*void OnSelectEnter()
    {
        meshRenderer.material = HittMaterial;
    }
    void OnSelectExit()
    {
        meshRenderer.material = defaultMaterial;
    }*/
// we used the onDisable() function to remove all the listeners ... to prevent memory leak
    void OnDisable()
    {
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
         interactable.hoverExited.RemoveListener(OnHoverExit);
       /* interactable.selectEntered.RemoveListener(enter => OnSelectEnter());
        interactable.selectExited.RemoveListener(exit => OnSelectExit());*/
    }

    // Update is called once per frame
    void Update()
    {

    }
}
