using UnityEngine;

public class LevelPass : MonoBehaviour
{
    public ManageFades UI;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            disableScripts();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            UI.EndUI.SetActive(true);
            UI.fade.GetComponent<Animator>().SetTrigger("Fade");
        }
    }

    void disableScripts()
    {
        GameObject.Find("Mechanics").SetActive(false);
        GameObject.Find("Player").SetActive(false);
        GameObject.Find("CamAnchor").SetActive(false);
        UI.gameObject.GetComponent<UIManager>().enabled = false;
    }
}
