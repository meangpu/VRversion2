using UnityEngine;
using TMPro;

public class boneNameShow : MonoBehaviour
{
    [SerializeField] TMP_Text boneName;

    private void Start() 
    {
        boneName.SetText("");
    }

    // private void OnTriggerEnter(Collider other) 
    // {
    //     if(other.gameObject.tag == "Bone")
    //     {
    //         boneName.SetText(other.gameObject.name);
    //     }
    // }

    public void setTextName(GameObject childSend)
    {
        boneName.SetText(childSend.name);
    }

    public void resetName()
    {
        boneName.SetText("");
    }
}
