using UnityEngine;

public class toolResetPosition : MonoBehaviour
{
    [SerializeField] Vector3 position;
    [SerializeField] Vector3 rotation;

    public void resetPosAndRot()
    {
        Debug.Log("weee");
        transform.position = position;
        transform.rotation = Quaternion.Euler(rotation);
    }

}
