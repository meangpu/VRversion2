using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class SeperateManager : MonoBehaviour
{
    [SerializeField] Transform[] _allTrans;
    [SerializeField] Ease easeType;
    [SerializeField] float increase;
    [SerializeField] float timeBetweenAll;
    [SerializeField] float staticTimeDuration;
    [SerializeField] float allAtOnceMultiple;
    public bool allAtOnce;

    [Header("UI")]
    [SerializeField] Toggle _toggle;
    [SerializeField] Slider _slider;
    [SerializeField] Button _mainButton;
    [SerializeField] Button _gravityBtn;
    [SerializeField] Image _btnImg;
    [SerializeField] TMP_Text _btn_text;

    [SerializeField] Color _blueCol;
    [SerializeField] Color _redCol;



    private List<Vector3> _oldPos = new List<Vector3>();
    private List<Quaternion> _oldRot = new List<Quaternion>();

    private List<BoxCollider> _allBox = new List<BoxCollider>();
    private List<Rigidbody> _allRb = new List<Rigidbody>();

    private bool isAlreadySep;
    private float startOffset = 0;

    // trigger cannot touch


    private void Start() 
    {
        foreach (Transform _tran in _allTrans)
        {
            _oldPos.Add(_tran.position);
            _oldRot.Add(_tran.rotation);

            _allBox.Add(_tran.GetComponent<BoxCollider>());
            _allRb.Add(_tran.GetComponent<Rigidbody>());
        }

        _slider.onValueChanged.AddListener((v) => 
        {
            timeBetweenAll = staticTimeDuration/v;
        });
    }


    void boxTriggerAndKine(bool _state, bool _kineState)
    {
        foreach (var _box in _allBox)
        {
            _box.isTrigger = _state;
        }

        foreach (var _rb in _allRb)
        {
            _rb.isKinematic = _kineState;
        }

    }

    public void changeButtonState()
    {
        if(isAlreadySep)
        {
            _btn_text.SetText("REWIND\n<size=17>separate</size>");
            _btnImg.color = _redCol;
        }
        else
        {
            _btn_text.SetText("START\n<size=17>separate</size>");
            _btnImg.color = _blueCol;
        }
    }

    public void doSepAll()
    {
        _gravityBtn.interactable = false;
        allAtOnce = _toggle.isOn;
        startOffset = -(_allTrans.Length) *.5f * increase;

        if(allAtOnce)
        {
            _mainButton.interactable = false;
            foreach (var _tran in _allTrans)
            {
                _tran.DOMoveX(_tran.position.x + startOffset, timeBetweenAll * allAtOnceMultiple).SetEase(easeType);
                startOffset += increase;
                // when finish
            }
            _mainButton.interactable = true;
        }
        else
        {
            _mainButton.interactable = false;
            var sequence = DOTween.Sequence();
            foreach (var _tran in _allTrans)
            {
                sequence.Append(_tran.DOMoveX(_tran.position.x + startOffset, timeBetweenAll).SetEase(easeType));
                startOffset += increase;
            }
            sequence.OnComplete(() => {
                _mainButton.interactable = true;
                boxTriggerAndKine(false, false);
                _gravityBtn.interactable = true;
            });
        }


    }


    public void undoSep()
    {
        boxTriggerAndKine(true, true);  // kinematic to prevent move
        _gravityBtn.interactable = false;

        allAtOnce = _toggle.isOn;
        if(allAtOnce)
        {
            _mainButton.interactable = false;
            for(int i = 0; i < _allTrans.Length; i++)
            {
                _allTrans[i].DOMove(_oldPos[i], timeBetweenAll * allAtOnceMultiple).SetEase(easeType);

                _allTrans[i].DORotateQuaternion(_oldRot[i], timeBetweenAll * allAtOnceMultiple).SetEase(easeType);

            }
            _mainButton.interactable = true;

        }
        else
        {
            _mainButton.interactable = false;
            var sequence = DOTween.Sequence();

            for(int i = 0; i < _allTrans.Length; i++)
            {
                sequence.Append(_allTrans[i].DOMove(_oldPos[i], timeBetweenAll*0.5f).SetEase(easeType));
                sequence.Append(_allTrans[i].DORotateQuaternion(_oldRot[i], timeBetweenAll*0.5f).SetEase(easeType));
            }
            sequence.OnComplete(() => {
                _mainButton.interactable = true;
            });

        }

        
    }


    public void buttonDoSep()
    {
        if (isAlreadySep)
        {
            undoSep();
        }
        else
        {
            doSepAll();
        }
        isAlreadySep = !isAlreadySep;
        changeButtonState();

    }




}
