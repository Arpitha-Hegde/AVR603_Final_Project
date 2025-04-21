using TMPro;
using UnityEngine;

public class QuestUIManager : MonoBehaviour
{
    public static QuestUIManager Instance;

    public GameObject questPanel;
    public TMP_Text questText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple QuestUIManager instances found! Destroying extra.");
            Destroy(gameObject);
        }

        if (questPanel != null)
            questPanel.SetActive(false);
        else
            Debug.LogError("QuestPanel is not assigned in QuestUIManager.");
    }

    public void ShowQuestMessage(string message)
    {
        if (questPanel == null || questText == null)
        {
            Debug.LogError("Quest UI elements are not assigned.");
            return;
        }

        questText.text = message;
        questText.gameObject.SetActive(true);
        questPanel.SetActive(true);

        CancelInvoke(nameof(HideQuestMessage));
        Invoke(nameof(HideQuestMessage), 10f);
    }

    void HideQuestMessage()
    {
        if (questPanel != null)
        {
            questText.gameObject.SetActive(false);
            questPanel.SetActive(false);
        }
    }
}