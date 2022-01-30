using UnityEngine;

public class ResetFusePosition : MonoBehaviour
{
    [SerializeField] Vector3 RespawnLocation;
    [SerializeField] Transform fuseObj;


    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "RespawnFloor")
        {
            fuseObj.localRotation = Quaternion.identity;
            fuseObj.localPosition = RespawnLocation;
        }
    }




}
