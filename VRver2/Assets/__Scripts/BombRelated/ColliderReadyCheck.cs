using UnityEngine;

public class ColliderReadyCheck : MonoBehaviour
{

    [SerializeField] ToolStatusManager toolReadyScpt;
    [SerializeField] string thisSlotName;


    private void OnTriggerEnter(Collider other) 
    {
        
        if (other.gameObject.tag != "LeftLa" && other.gameObject.tag != "RightLa" && other.gameObject.tag != "CamTool" )
        {
            return;
        }
        else
        {
            toolReadyScpt.checkWithTagName(other.gameObject, thisSlotName);
        }
 
    }
}
