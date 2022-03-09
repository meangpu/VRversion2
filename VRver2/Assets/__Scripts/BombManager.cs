using UnityEngine;

public class BombManager : MonoBehaviour
{
    [SerializeField] Rigidbody[] _rb;
    [SerializeField] Collider[] _col;

    public void BombGravityOn()
    {
        foreach (Rigidbody _r in _rb)
        {
            _r.useGravity = true;
            _r.isKinematic = false;
            _r.constraints = RigidbodyConstraints.None;
        }

        foreach (Collider _c in _col)
        {
            _c.isTrigger = false;
        }
    }

    // Seperate Mesh
    public void BombGravityOff()
    {
        foreach (Rigidbody _r in _rb)
        {
            _r.isKinematic = true;
            // _r.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

            _r.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            
            
        }

        foreach (Collider _c in _col)
        {
            _c.isTrigger = false;
        }
    }

    public void BombGravityOffKineOff()
    {
        foreach (Rigidbody _r in _rb)
        {
            _r.isKinematic = false;
            _r.constraints = RigidbodyConstraints.None;
        }

        foreach (Collider _c in _col)
        {
            _c.isTrigger = false;
        }
    }

}
