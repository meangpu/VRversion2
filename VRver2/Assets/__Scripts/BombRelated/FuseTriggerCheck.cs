using UnityEngine;
using TMPro;

public class FuseTriggerCheck : MonoBehaviour
{
    [SerializeField] TMP_Text fuseQuestText;

    private void OnTriggerEnter(Collider other) 
    {
        
        if (other.gameObject.tag != "Fuse")
        {
            Debug.Log(other.gameObject.tag);
            return;
        }
        else
        {
            QuestManager.Instance.finishQuest(fuseQuestText);

            Debug.Log("Yeah wow finish fuse");
        }
 
    }

}
