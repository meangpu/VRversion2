using UnityEngine;

public class toolResetPosition : MonoBehaviour
{
    [SerializeField] Vector3 position;
    [SerializeField] Vector3 rotation;
    Rigidbody rb;

    private void Start() {
        rb = transform.GetComponent<Rigidbody>();
    }



    public void resetPosAndRot()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = position;
        transform.rotation = Quaternion.Euler(rotation);
    }

}
