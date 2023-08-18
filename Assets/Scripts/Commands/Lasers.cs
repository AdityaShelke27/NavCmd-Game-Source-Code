using UnityEngine;
using UnityEngine.SceneManagement;

public class Lasers : MonoBehaviour
{
    public static bool canEquip;
    public Transform eyeRight;
    public Transform eyeLeft;
    public LineRenderer laserRight;
    public LineRenderer laserLeft;
    public Vector3 headPos;
    public float laserCount = 3;
    public TechInventory tech;
    public GameObject lasRsd;
    public LayerMask noPlayer;

    private void Awake()
    {
        tech = GetComponent<TechInventory>();
        laserRight = eyeRight.GetComponent<LineRenderer>();
        laserLeft = eyeLeft.GetComponent<LineRenderer>();
        laserRight.enabled = false;
        laserLeft.enabled = false;
        laserRight.useWorldSpace = true;
        laserLeft.useWorldSpace = true;
    }
    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level 4")
        {
            canEquip = true;
        }
    }
    public void options(string opt)
    {
        if(canEquip)
        {
            switch(opt)
            {
                case "SMALL":                 
                    if(small())
                    {
                        tech.cmdCount++;
                    }
                    break;

                default:
                    string reason = "Invalid Command:\n" + Commands.cmd[tech.cmdCount];
                    FindObjectOfType<Loadlevel>().levelFailed(reason);
                    break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(headPos, transform.forward - transform.up);
    }
    bool small()
    {
        
        if (laserCount > 0)
        {
            laserRight.enabled = true;
            laserLeft.enabled = true;
            lasRsd.SetActive(true);

            laserRight.SetPosition(1, eyeRight.position);
            laserLeft.SetPosition(1, eyeLeft.position);

            headPos = (eyeRight.position + eyeLeft.position) / 2;

            RaycastHit hit;
            if(Physics.Raycast(headPos, transform.forward - transform.up, out hit, 2, noPlayer))
            {
                laserRight.SetPosition(0, hit.point);
                laserLeft.SetPosition(0, hit.point);
                lasRsd.transform.position = hit.point;

                if (hit.transform.tag == "Obstacle")
                {
                    Destroy(hit.transform.gameObject, laserCount);
                }
            }

            laserCount -= Time.deltaTime;

            return false;
        }
        else
        {
            laserRight.enabled = false;
            laserLeft.enabled = false;
            laserCount = 3;
            lasRsd.SetActive(false);

            return true;
        }
    }
}
