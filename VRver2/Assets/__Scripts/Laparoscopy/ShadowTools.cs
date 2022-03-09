using UnityEngine;

public class ShadowTools : MonoBehaviour
{

    [Header("Parent")]
    [SerializeField] Transform parentLeft;
    [SerializeField] Transform parentCam;
    [SerializeField] Transform parentRight;

    [Header("MainTools")]
    [SerializeField] Transform leftTool;
    [SerializeField] Transform camTool;
    [SerializeField] Transform rightTool;

    
    [Header("Child")]
    [SerializeField] Transform[] childLeft;
    [SerializeField] Transform childCam;
    [SerializeField] Transform[] childRight;


    private Vector3 leftRot;
    private Vector3 camRot;
    private Vector3 righRot;

    private Vector3 leftPos;
    private Vector3 camPos;
    private Vector3 righPos;

    [SerializeField] Vector3 leftClampVal;
    [SerializeField] Vector3 camClampVal;
    [SerializeField] Vector3 rightClampVal;

    [SerializeField] Vector3 leftClampPos;
    [SerializeField] Vector3 camClampPos;
    [SerializeField] Vector3 rightClampPos;

    [SerializeField] bool startClamp;


    public void saveRotation()
    {
        leftRot = leftTool.rotation.eulerAngles;
        camRot = camTool.rotation.eulerAngles;
        righRot = rightTool.rotation.eulerAngles;

        parentLeft.eulerAngles = leftRot;
        parentRight.eulerAngles = camRot;
        parentRight.eulerAngles = righRot;

        leftPos = leftTool.position;
        camPos = camTool.position;
        righPos = rightTool.position;

    }


    public void doStartClamp()
    {
        saveRotation();
        startClamp = true;
    }

    public static float ClampAngle(float angle, float min, float max) 
    {
        float start = (min + max) * 0.5f - 180;
        float floor = Mathf.FloorToInt((angle - start) / 360) * 360;
        min += floor;
        max += floor;
        return Mathf.Clamp(angle, min, max);
    }

    public float rotCanNegative(float _angle)
    {
        if(_angle >= 180)
        {
            _angle -= 360;
        }
        return _angle % 360;
    }

    private void Update() 
    {

        if(!startClamp)
        {
            return;
        }
        else
        {
            clampRotAndPos();
        }
    }

    private void clampRotAndPos()
    {
        Vector3 leftParent = parentLeft.rotation.eulerAngles;
        Vector3 camParent = parentCam.rotation.eulerAngles;
        Vector3 rightParent = parentRight.rotation.eulerAngles;

        Vector3 leftParentPos = parentLeft.position;
        Vector3 camParentPos = parentCam.position;
        Vector3 rightParentPos = parentRight.position;

        Vector3 targetLeftAngle = new Vector3
            (
                ClampAngle(leftParent.x, leftRot.x - leftClampVal.x, leftRot.x + leftClampVal.x),
                ClampAngle(leftParent.y, leftRot.y - leftClampVal.y, leftRot.y + leftClampVal.y),
                ClampAngle(leftParent.z, leftRot.z - leftClampVal.z, leftRot.z + leftClampVal.z)
            );

        Vector3 targetCamAngle = new Vector3
            (
                ClampAngle(camParent.x, camRot.x - camClampVal.x, camRot.x + camClampVal.x),
                ClampAngle(camParent.y, camRot.y - camClampVal.y, camRot.y + camClampVal.y),
                ClampAngle(camParent.z, camRot.z - camClampVal.z, camRot.z + camClampVal.z)
            );

        Vector3 targetRightAngle = new Vector3
            (
                ClampAngle(rightParent.x, righRot.x - rightClampVal.x, righRot.x + rightClampVal.x),
                ClampAngle(rightParent.y, righRot.y - rightClampVal.y, righRot.y + rightClampVal.y),
                ClampAngle(rightParent.z, righRot.z - rightClampVal.z, righRot.z + rightClampVal.z)
            );

        // Pos
        Vector3 targetLeftPos = new Vector3
            (
                Mathf.Clamp(leftParentPos.x, leftPos.x - leftClampPos.x, leftPos.x + leftClampPos.x),
                Mathf.Clamp(leftParentPos.y, leftPos.y - leftClampPos.y, leftPos.y + leftClampPos.y),
                Mathf.Clamp(leftParentPos.z, leftPos.z - leftClampPos.z, leftPos.z + leftClampPos.z)
            );

        Vector3 targetCamPos = new Vector3
            (
                Mathf.Clamp(camParentPos.x, camPos.x - camClampPos.x, camPos.x + camClampPos.x),
                Mathf.Clamp(camParentPos.y, camPos.y - camClampPos.y, camPos.y + camClampPos.y),
                Mathf.Clamp(camParentPos.z, camPos.z - camClampPos.z, camPos.z + camClampPos.z)
            );

        Vector3 targetRightPos = new Vector3
            (
                Mathf.Clamp(rightParentPos.x, righPos.x - rightClampPos.x, righPos.x + rightClampPos.x),
                Mathf.Clamp(rightParentPos.y, righPos.y - rightClampPos.y, righPos.y + rightClampPos.y),
                Mathf.Clamp(rightParentPos.z, righPos.z - rightClampPos.z, righPos.z + rightClampPos.z)
            );


        // childCam.eulerAngles = targetCamAngle;

        foreach (Transform cLeft in childLeft)
        {
            cLeft.rotation = Quaternion.Euler(targetLeftAngle);
            // cLeft.position = targetLeftPos;

            cLeft.position = parentLeft.position;
        }

        foreach (Transform cRight in childRight)
        {

            cRight.rotation = Quaternion.Euler(targetRightAngle);
            // cRight.position = targetRightPos;

            cRight.position = parentRight.position;

        }
    }





}
