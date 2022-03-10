using UnityEngine;

public class toolResetPosition : MonoBehaviour
{
    [SerializeField] Vector3 position;
    [SerializeField] Vector3 rotation;

    public void resetPosAndRot()
    {
        transform.position = position;
        transform.rotation = Quaternion.Euler(rotation);
    }

}
