using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public bool QuestStarted = false;
    public bool QuestCompleted = false;
    public bool QuestFailed = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void EndGame(bool success)
    {
        if (QuestCompleted || QuestFailed) return; // already ended

        if (success)
        {
            QuestCompleted = true;
            QuestUIManager.Instance.ShowQuestMessage("<color=green><b>Accessing terminal... Message transmission initiated. Retrieving encrypted files...</b></color>");
        }
        else
        {
            QuestFailed = true;
            QuestUIManager.Instance.ShowQuestMessage("<color=red><b>Mission Failed! The chaser bot caught you.</b></color>");
        }

        // Stop the game
        Time.timeScale = 0f;
    }
}