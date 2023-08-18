using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("Level 0");
    }
    public void TutorialBtn()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void AboutBtn()
    {

    }
    public void ExitBtn()
    {
        Application.Quit();
    }
}
