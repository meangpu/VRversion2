using UnityEngine;
using TMPro;
using System;

[System.Serializable]
public class QuestItem
{
    public string questName;
    public bool status = false;
    public TMP_Text missionTmp;

    public void finishThisQuest()
    {
        if(status)
        {
            return;
        }
        else
        {
            status = true;
            missionTmp.color = QuestManager.Instance.correctCol;
            QuestManager.Instance.nowFinished++; 
        }
    }
}


public class QuestManager : MonoBehaviour
{
    public int numBeforePressButton = 2;
    public int nowFinished = 0;
    public static QuestManager Instance;
    public Color correctCol;
    public QuestItem[] questLists;

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

    public void finishQuestByName(string _questName)
    {
        QuestItem q = Array.Find(questLists, ans => ans.questName == _questName);
        if(q==null)
        {
            return;
        }
        q.finishThisQuest();
    }

    [ContextMenu("CHEEEEEE")]
    public void finishWire()
    {
        finishQuestByName("Wire");
    }


}
