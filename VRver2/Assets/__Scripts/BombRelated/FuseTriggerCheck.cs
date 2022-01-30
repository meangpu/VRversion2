using UnityEngine;
using TMPro;

public class FuseTriggerCheck : MonoBehaviour
{
    [SerializeField] TMP_Text fuseQuestText;

    private void OnTriggerEnter(Collider other) 
    {
        
        if (other.gameObject.tag != "Fuse")
        {
            return;
        }
        else
        {
 
            QuestManager.Instance.finishQuestByName("Fuse");
            FindObjectOfType<AudioManager>().Play("BombButtonRight");
        }
 
    }

}
