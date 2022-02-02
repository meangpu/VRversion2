using UnityEngine;

public class ShadowTools : MonoBehaviour
{
    [Header("Parent")]
    [SerializeField] Transform parentLeft;
    [SerializeField] Transform parentRight;
    [Header("Child")]
    [SerializeField] Transform childLeft;
    [SerializeField] Transform childRight;


    private void FixedUpdate() 
    {
        Vector3 leftParent = parentLeft.rotation.eulerAngles;
        Vector3 rightParent = parentRight.rotation.eulerAngles;
        
        childLeft.eulerAngles = leftParent;
        childRight.eulerAngles = rightParent;
    }





    
}
