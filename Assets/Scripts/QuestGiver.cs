using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    private bool playerInRange = false;
    private bool questGiven = false;

    private string questMessage = "<b><size=120%><color=black>Welcome, Unit-7!</color></size></b>\n\n" +
        "<color=black>Your mission is <b>critical</b>. Locate the central computer console within the maze. Transmit the encrypted message and retrieve the classified data. Proceed with caution.</color>\n" +
        "<color=black>Beware of the </color><color=red>Patrol and Chaser Bots</color><color=black> that are roaming the corridors.</color>.\n" +
        "<color=black>Avoid the <color=yellow>Zombie Bots</color> lurking in the shadows.</color>\n\n" +
        "<color=black>Good luck! The maze awaits.</color>";

    void Update()
    {
        // Only show quest once when player enters range
        if (playerInRange && !questGiven)
        {
            questGiven = true;

            if (QuestUIManager.Instance != null)
                QuestUIManager.Instance.ShowQuestMessage(questMessage);
            else
                Debug.LogError("QuestUIManager.Instance is null.");

            if (QuestManager.Instance != null)
                QuestManager.Instance.QuestStarted = true;
            else
                Debug.LogError("QuestManager.Instance is null.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered NPC range");
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left NPC range");
            playerInRange = false;
        }
    }
}