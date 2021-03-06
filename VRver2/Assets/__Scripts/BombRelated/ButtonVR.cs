using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    [SerializeField] GameObject button;
    string pressTag;
    bool isPress;


    void Start()
    {
        isPress = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(!isPress)
        {
            button.transform.localPosition = new Vector3(0, 0.08f, 0);
            pressTag = other.gameObject.tag;
            isPress = true;
            bool isWinIng = checkIfCanWin();
            if(isWinIng)
            {
                QuestManager.Instance.finishQuestByName("Button");
                FindObjectOfType<AudioManager>().Play("BombButtonRight");

                GameManager.Instance.UpdateGameState(GameState.Wingame);

            }
            else
            {
                Timer[] allTimer = FindObjectsOfType<Timer>();
                foreach (Timer t in allTimer)
                {
                    t.subtractTime(5f);
                }
                FindObjectOfType<AudioManager>().Play("BombButtonWrong");
            }

        }
        // QuestManager.Instance.finishQuestByName("Button");
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == pressTag)
        {
            button.transform.localPosition = new Vector3(0, 0.6f, 0);
            isPress = false;
        }
    }
    

    private bool checkIfCanWin()
    {
        if (QuestManager.Instance.nowFinished >= QuestManager.Instance.numBeforePressButton)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
