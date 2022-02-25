using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GravityControl : MonoBehaviour
{
    [SerializeField] Rigidbody[] _allRB;
    [SerializeField] Image btnImg;
    [SerializeField] TMP_Text btnText;

    [SerializeField] Color greenCol;
    [SerializeField] Color redCol;

    private bool isUsed;

    void turnAllRb(bool _state)
    {
        foreach (Rigidbody _rb in _allRB)
        {
            _rb.useGravity = _state;
        }
    }
    
    void setBtnAs(Color _col, string _word)
    {
        btnImg.color = _col;
        btnText.SetText(_word);
    }

    public void buttonRb()
    {
        if(isUsed)
        {
            turnAllRb(false);
            setBtnAs(redCol, "OFF");
        }
        else
        {
            turnAllRb(true);
            setBtnAs(greenCol, "ON");
            
        }

        isUsed = !isUsed;
    }
}
