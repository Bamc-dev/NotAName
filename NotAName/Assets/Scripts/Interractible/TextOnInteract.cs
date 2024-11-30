using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextOnInteract : MonoBehaviour
{
    [SerializeField] private Text messageText; // R�f�rence au composant Text
    [SerializeField] private string[] messages; // Liste des messages
    [SerializeField] private float delayBetweenMessages; // D�lai entre les messages

    private bool alreadyLaunch = false;

    public KeyCode pickKey = KeyCode.E;
    public float pickUpRange = 3f;
    public Transform player;
    private bool inRange = false;

    public void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        inRange = distanceToPlayer <= pickUpRange;


        if (UserInput.Instance.InteractInput && inRange)
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (alreadyLaunch == false)
        {
            if (messageText == null)
            {
                Debug.LogError("Le champ 'messageText' n'est pas assign�.");
                return;
            }

            if (messages.Length == 0)
            {
                Debug.LogWarning("La liste des messages est vide.");
                return;
            }

            alreadyLaunch = true;
            StartCoroutine(DisplayMessages());
        }
    }

    private IEnumerator DisplayMessages()
    {
        foreach (string message in messages)
        {
            messageText.text = message; // Mettre � jour le texte
            Debug.Log(message);
            yield return new WaitForSeconds(delayBetweenMessages); // Attendre le d�lai
        }

        messageText.text = ""; // Nettoyer le texte apr�s la fin des messages
    }
}
