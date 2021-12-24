using UnityEngine;

public class rope : MonoBehaviour
{
    public Rigidbody RbFirstHook;
    [SerializeField] HingeJoint endHookJoint;

    [SerializeField] GameObject linkPrefabs;
    [SerializeField] int linksCount;
    [SerializeField] Vector3 distanceBetweenJoin;
    [SerializeField] Vector3 offsetEnd;
    


    void Start()
    {
        endHookJoint.transform.localPosition = (distanceBetweenJoin * linksCount) + offsetEnd;
        GenerateRope();
    }

    void GenerateRope()
    {
        Vector3 spawnPos = transform.position + distanceBetweenJoin;

        Rigidbody previousHook = RbFirstHook;
        endHookJoint.connectedAnchor = distanceBetweenJoin;

        for (int i = 0; i < linksCount; i++)
        {
            GameObject link = Instantiate(linkPrefabs, spawnPos, Quaternion.identity, transform);
            HingeJoint join = link.GetComponent<HingeJoint>();
            join.connectedBody = previousHook;
            join.connectedAnchor = distanceBetweenJoin;


            if (i < linksCount-1)  // not last one
            {
                previousHook = link.GetComponent<Rigidbody>();
            }
            else
            {
                previousHook = link.GetComponent<Rigidbody>();
                endHookJoint.connectedBody = previousHook;
            }

            spawnPos += distanceBetweenJoin;

        }
    }
}
