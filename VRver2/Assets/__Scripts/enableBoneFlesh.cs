using UnityEngine;
using UnityEngine.UI;

public class enableBoneFlesh : MonoBehaviour
{
    [SerializeField] GameObject[] allBone;
    [SerializeField] GameObject[] allFlesh;

    [SerializeField] Color boneTrue;
    [SerializeField] Color boneFalse;

    [SerializeField] Color fleshTrue;
    [SerializeField] Color fleshFalse;

    [SerializeField] Image boneBtn;
    [SerializeField] Image fleshBtn;

    bool disableBone;
    bool disableFlesh;

    public void BoneButton()
    {
        disableBone = doCheckAndAction(allBone, disableBone, boneBtn, boneFalse, boneTrue);
    }

    public void FleshButton()
    {
        disableFlesh = doCheckAndAction(allFlesh, disableFlesh, fleshBtn, fleshFalse ,fleshTrue);
    }


    public bool doCheckAndAction(GameObject[] _list, bool _bool, Image _but, Color _fCol, Color _tCol)
    {
        if(!_bool) // ถ้าไม่ disable bone ให้ dis
        {
            foreach (GameObject _b in _list)
            {
                _b.SetActive(false);
                _but.color = _fCol;
            }
        }
        else
        {
            foreach (GameObject _b in _list)
            {
                _b.SetActive(true);
                _but.color = _tCol;

            }
        }

        return !_bool;
    }




}
