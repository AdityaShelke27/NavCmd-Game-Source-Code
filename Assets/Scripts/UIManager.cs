using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Slider slider;
    public TMPro.TextMeshProUGUI sliderText;
    public GameObject PauseMenu;
    private bool isPaused;

    private void Awake()
    {
        PauseMenu.SetActive(false);
    }

    private void Start()
    {
        sliderText.text = string.Format("{0, 0:F2}", slider.value);
        slider.value = 1;
        isPaused = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseMenu();
        }
        if (isPaused)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = slider.value;
            PauseMenu.SetActive(false);
        }
    }

    public void timeSlider()
    {
        Time.timeScale = slider.value;
        sliderText.text = string.Format("{0, 0:F2}", slider.value);
    }


    public void pauseMenu()
    {
        isPaused = !isPaused;
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
