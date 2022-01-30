using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    [SerializeField] Color correctCol;

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void finishQuest(TMP_Text MissionText)
    {
        MissionText.color = correctCol;
    }


}
