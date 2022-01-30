using UnityEngine;

public class ScissorHead : MonoBehaviour
{
    [SerializeField] GameObject cutObject;

    public void enableCut()
    {
        cutObject.SetActive(true);
    }

    public void disableCut()
    {
        cutObject.SetActive(false);
    }

}
