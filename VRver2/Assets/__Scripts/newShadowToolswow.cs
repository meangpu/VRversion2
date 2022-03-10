using UnityEngine;

public class newShadowToolswow : MonoBehaviour
{
    [SerializeField] Transform c1Tran;
    [SerializeField] Transform c2Tran;
    [SerializeField] Vector3 offset1;
    [SerializeField] Vector3 offset2;

    void Update()
    {
        c1Tran.position = transform.position + offset1;
        c2Tran.position = transform.position + offset2;
        c1Tran.rotation = Quaternion.Euler(transform.rotation.eulerAngles);
        c2Tran.rotation = Quaternion.Euler(transform.rotation.eulerAngles);
    }
}
