using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/// <summary>
/// Defines the type of piece this spawner will produce.
/// </summary>
public enum PieceType { X, O }

/// <summary>
/// Attach this script to the source GameObject (e.g., the 'O' or 'X' piece prefab
/// used as the spawner). When the piece is grabbed, it creates a clone and
/// immediately transfers the grab to the clone, leaving the original in place.
/// This acts as an "infinite" source for game pieces.
/// </summary>
[RequireComponent(typeof(XRGrabInteractable))]
public class PieceSpawnerGrab : MonoBehaviour
{
    [Tooltip("Set the type of piece this spawner should generate.")]
    public PieceType pieceType = PieceType.O; // Default to O, but must be set on X spawner
   [HideInInspector] public GameObject ClonePieceObject; // The newly spawned piece instance
    public static PieceSpawnerGrab instance; // Static reference for easy access if needed
    // A reference to the XRGrabInteractable component on this object
    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        // Get the Grab Interactable component
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        // Subscribe to the event that fires when the interactor (hand/controller)
        // first initiates a successful grab on this object.
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabStart);
        }
    }

    void OnDisable()
    {
        // Always unsubscribe to prevent memory leaks or errors
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabStart);
        }
    }

    /// <summary>
    /// Called when an interactor (hand/controller) grabs this object.
    /// </summary>
    /// <param name="args">The event arguments, containing the interactor that grabbed the piece.</param>
    private void OnGrabStart(SelectEnterEventArgs args)
    {
        // 1. Get the interactor that grabbed the original piece (the hand/controller)
        IXRSelectInteractor interactor = args.interactorObject;

        // 2. Clear the interaction on the original spawner piece
        // This is crucial: we are stopping the grab on the original piece.
        grabInteractable.interactionManager.SelectExit(interactor, grabInteractable);

        // 3. Create a new instance (the actual piece the player will place)
        ClonePieceObject = Instantiate(gameObject, transform.position, transform.rotation);
        ClonePieceObject.GetComponent<Rigidbody>().isKinematic = false;
        ClonePieceObject.GetComponent<Rigidbody>().useGravity = true;


        // 4. Set up the new piece

        // Remove this script from the clone so it doesn't try to spawn another piece when grabbed later
        Destroy(ClonePieceObject.GetComponent<PieceSpawnerGrab>());

        // Mark the clone for identification in the scene hierarchy
        ClonePieceObject.name = $"{pieceType.ToString()}_ActivePiece";

        // 5. Transfer the grab to the new piece
        // This tells the interactor to start grabbing the newly created piece instead.
        // The player doesn't notice the hand-off.
        XRGrabInteractable newGrabInteractable = ClonePieceObject.GetComponent<XRGrabInteractable>();

        if (newGrabInteractable != null)
        {
            grabInteractable.interactionManager.SelectEnter(interactor, newGrabInteractable);

            // Optional: You might want to add a script here (e.g., GamePiece.cs) 
            // that simply holds the PieceType property for later use by the sockets.
        }
        else
        {
            Debug.LogError("The cloned piece is missing the XRGrabInteractable component! Check the prefab setup.");
        }

    }
    
}
