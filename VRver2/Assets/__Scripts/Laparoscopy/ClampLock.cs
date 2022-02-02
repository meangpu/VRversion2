using UnityEngine;

public class ClampLock : MonoBehaviour
{

    [SerializeField] Transform leftT;
    [SerializeField] Transform camT;
    [SerializeField] Transform rightT;

    private Vector3 leftRot;
    private Vector3 camRot;
    private Vector3 righRot;

    [SerializeField] Vector3 leftClampVal;
    [SerializeField] Vector3 camClampVal;
    [SerializeField] Vector3 rightClampVal;

    [SerializeField] bool startClamp;

    public void saveRotation()
    {
        leftRot = leftT.rotation.eulerAngles;
        camRot = camT.rotation.eulerAngles;
        righRot = rightT.rotation.eulerAngles;
    }

    public void doStartClamp()
    {
        startClamp = true;
    }

    private void FixedUpdate() 
    {
        if(!startClamp)
        {
            return;
        }
        else
        {
            leftT.eulerAngles = new Vector3
            (
                Mathf.Clamp(leftT.eulerAngles.x, leftRot.x - leftClampVal.x, leftRot.x + leftClampVal.x),
                Mathf.Clamp(leftT.eulerAngles.y, leftRot.y - leftClampVal.y, leftRot.y + leftClampVal.y),
                Mathf.Clamp(leftT.eulerAngles.z, leftRot.z - leftClampVal.z, leftRot.z + leftClampVal.z)
            );


            camT.eulerAngles = new Vector3
            (
                Mathf.Clamp(camT.eulerAngles.x, camRot.x - camClampVal.x, camRot.x + camClampVal.x),
                Mathf.Clamp(camT.eulerAngles.y, camRot.y - camClampVal.y, camRot.y + camClampVal.y),
                Mathf.Clamp(camT.eulerAngles.z, camRot.z - camClampVal.z, camRot.z + camClampVal.z)
            );

            rightT.eulerAngles = new Vector3
            (
                Mathf.Clamp(rightT.eulerAngles.x, righRot.x - rightClampVal.x, righRot.x + rightClampVal.x),
                Mathf.Clamp(rightT.eulerAngles.y, righRot.y - rightClampVal.y, righRot.y + rightClampVal.y),
                Mathf.Clamp(rightT.eulerAngles.z, righRot.z - rightClampVal.z, righRot.z + rightClampVal.z)
            );



        }
    }





}
