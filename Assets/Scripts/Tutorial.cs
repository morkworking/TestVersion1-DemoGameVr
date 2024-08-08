using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public Toggle Checkbottom;
    public Toggle Checkbottom2;
    public GameObject Wall2;
    public AudioClip taskCompletedSound; // Reference to the sound clip
    private bool task1Completed = false;
    private bool task2Completed = false;
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for collision with a wall
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Task 1 completed: Collided with a wall!");
            task1Completed = true;
            Checkbottom.GetComponent<Toggle>().isOn = true;
        }
        // Check for the clipboard entering the tray
        else if (other.gameObject.CompareTag("Clipboard"))
        {
            Debug.Log("Task 2 completed: Pick up the clipboard");
            task2Completed = true;
            Checkbottom2.GetComponent<Toggle>().isOn = true;

            // Play the sound effect
            if (taskCompletedSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(taskCompletedSound);
            }
        }
    }
}