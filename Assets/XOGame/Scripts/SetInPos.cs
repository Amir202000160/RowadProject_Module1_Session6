using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SetInPos : MonoBehaviour
{
    public PieceSpawnerGrab pieceSpawnerGrab;
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Square"))
        {
            Debug.Log("Collided with a square");
            //pieceSpawnerGrab.ClonePieceObject.GetComponent<XRGrabInteractable>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
