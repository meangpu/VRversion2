using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void GoToString(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void GoToIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void RestartThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
