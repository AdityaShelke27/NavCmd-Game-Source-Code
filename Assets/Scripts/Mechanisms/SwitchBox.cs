using UnityEngine;

public class SwitchBox : MonoBehaviour
{
    private TechInventory inventory;
    public Transform platform;
    public Vector3 switchPos;
    private Vector3 distPos;
    public float minError;
    public Animator anim;
    private bool firstTime = true;
    public GameObject lever;
    public Color color;
    private void Awake()
    {
        distPos = platform.transform.localPosition + switchPos;
        lever.GetComponent<MeshRenderer>().material.color = color;
        platform.GetComponent<MeshRenderer>().material.color = color;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inventory = other.GetComponent<TechInventory>();
            inventory.use = operate;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inventory.use -= operate;
        }
    }
    public void operate()
    {
        if(firstTime)
        {
            firstTime = false;
            anim.SetBool("canPull", !anim.GetBool("canPull"));
        }
        if(Vector3.Distance(platform.transform.localPosition, distPos) > minError)
        {
            platform.transform.localPosition = Vector3.Lerp(platform.transform.localPosition, distPos, 0.5f);
        }
        else
        {
            firstTime = true;
            distPos -= switchPos;
            inventory.cmdCount++;          
        }
    }
}
