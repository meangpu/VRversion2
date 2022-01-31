using UnityEngine;

public class MoverHead : MonoBehaviour
{
    [SerializeField] GameObject moveObject;

    public void enableMove()
    {
        moveObject.SetActive(true);
    }

    public void disableMove()
    {
        moveObject.SetActive(false);
    }

}
