using UnityEngine;

public class ManageFades : MonoBehaviour
{
    public GameObject EndUI;
    public GameObject fade;
    // Start is called before the first frame update
    void Start()
    {
        EndUI.SetActive(false);
        fade.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
