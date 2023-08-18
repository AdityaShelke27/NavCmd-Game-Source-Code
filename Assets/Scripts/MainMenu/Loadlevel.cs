using UnityEngine.SceneManagement;
using UnityEngine;

public class Loadlevel : MonoBehaviour
{
    public GameObject fail;

    private void Awake()
    {
        fail.SetActive(false);
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void goHome()
    {
        SceneManager.LoadScene(0);
    }

    public void levelFailed(string reason)
    {
        GameObject.Find("Player").SetActive(false);
        fail.SetActive(true);
        fail.transform.GetChild(3).GetComponent<TMPro.TextMeshProUGUI>().text = reason;
        Time.timeScale = 0;
    }
}
