using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireTrigger : MonoBehaviour
{
    public XRSocketInteractor socket;  // Reference to the socket interactor
    public ParticleSystem fireEffect;  // Reference to the fire particle system

    // Method called when the book is placed in the socket
    private void OnEnable()
    {
        // Subscribe to the select event
        socket.selectEntered.AddListener(OnBookPlaced);
    }

    // Method called when the script is disabled or destroyed
    private void OnDisable()
    {
        // Unsubscribe from the select event to avoid memory leaks
        socket.selectEntered.RemoveListener(OnBookPlaced);
    }

    // This method is triggered when an object is placed in the socket
    private void OnBookPlaced(SelectEnterEventArgs args)
    {
        // Check if the object placed is the book (you can use tags or names for identification)
        if (args.interactableObject.transform.CompareTag("Book"))
        {
            // Start the fire effect
            fireEffect.Play();
        }
    }
}
