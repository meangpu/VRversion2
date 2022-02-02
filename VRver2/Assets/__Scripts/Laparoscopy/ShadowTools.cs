using UnityEngine;

public class ShadowTools : MonoBehaviour
{

    [Header("Parent")]
    [SerializeField] Transform parentLeft;
    [SerializeField] Transform parentRight;

    [Header("MainTools")]
    [SerializeField] Transform leftTool;
    [SerializeField] Transform rightTool;

    
    [Header("Child")]
    [SerializeField] Transform[] childLeft;
    [SerializeField] Transform[] childRight;


    private Vector3 leftRot;
    private Vector3 camRot;
    private Vector3 righRot;

    [SerializeField] Vector3 leftClampVal;
    [SerializeField] Vector3 camClampVal;
    [SerializeField] Vector3 rightClampVal;

    [SerializeField] bool startClamp;


    public void saveRotation()
    {
        leftRot = leftTool.rotation.eulerAngles;
        righRot = rightTool.rotation.eulerAngles;


        parentLeft.eulerAngles = leftRot;
        parentRight.eulerAngles = righRot;
    }

    public void doStartClamp()
    {
        saveRotation();
        startClamp = true;
    }


    private void Update() 
    {

        if(!startClamp)
        {
            return;
        }
        else
        {
            Vector3 leftParent = parentLeft.rotation.eulerAngles;
            Vector3 rightParent = parentRight.rotation.eulerAngles;

            Vector3 targetLeftAngle = new Vector3
                (
                    Mathf.Clamp(leftParent.x, leftRot.x - leftClampVal.x, leftRot.x + leftClampVal.x),
                    Mathf.Clamp(leftParent.y, leftRot.y - leftClampVal.y, leftRot.y + leftClampVal.y),
                    Mathf.Clamp(leftParent.z, leftRot.z - leftClampVal.z, leftRot.z + leftClampVal.z)
                );

            Vector3 targetRightAngle = new Vector3
                (
                    Mathf.Clamp(rightParent.x, righRot.x - rightClampVal.x, righRot.x + rightClampVal.x),
                    Mathf.Clamp(rightParent.y, righRot.y - rightClampVal.y, righRot.y + rightClampVal.y),
                    Mathf.Clamp(rightParent.z, righRot.z - rightClampVal.z, righRot.z + rightClampVal.z)
                );

            foreach (Transform cLeft in childLeft)
            {
                cLeft.eulerAngles = targetLeftAngle;
            }

            foreach (Transform cRight in childRight)
            {
                cRight.eulerAngles = targetRightAngle;
            }


        }

    }





    
}
