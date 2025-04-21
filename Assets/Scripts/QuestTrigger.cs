using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (QuestManager.Instance != null && QuestManager.Instance.QuestStarted && !QuestManager.Instance.QuestCompleted)
        {
            QuestManager.Instance.EndGame(true); // Success!
        }
   }
}