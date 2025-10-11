using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform[] squares = new Transform[9];
   public PieceSpawnerGrab pieceSpawner;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    foreach (var square in squares)
        {if (square.transform == pieceSpawner.ClonePieceObject.transform)
            {
                Debug.Log("Found it");
                PieceSpawnerGrab.instance.ClonePieceObject.GetComponent<XRGrabInteractable>().enabled = false;
            }
                
        }
    }
}
