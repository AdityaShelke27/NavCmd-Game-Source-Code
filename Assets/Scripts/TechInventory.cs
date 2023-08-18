using UnityEngine;
using System;
using UnityEngine.UI;

public class TechInventory : MonoBehaviour
{
    public Commands cmd;
    public int cmdCount;
    public bool canGo;
    public Button changeCam;
    public Button enterCommand;
    public Button clearCommand;
    public Button executeCommand;
    public GameObject cam;
    public Animator anim;
    public Lasers las;
    public Movement mov;
    public delegate void TechInventoryDelegate();
    public TechInventoryDelegate use;

    private void Start()
    {
        canGo = false;
    }
    private void Awake()
    {
        cmdCount = 0;
        las = GetComponent<Lasers>();
        mov = GetComponent<Movement>();
    }

    private void FixedUpdate()
    {
        bool isTrue = anim.GetCurrentAnimatorStateInfo(0).IsName("Idle");
        if(isTrue)
        {
            checkMoves();
        }
    }
    public void changeGo()
    {
        canGo = true;
        changeCam.interactable = false;
        enterCommand.interactable = false;
        clearCommand.interactable = false;
        executeCommand.interactable = false;
        cam.GetComponent<CameraPos>().swt = true;
    }

    void checkMoves()
    {
        if (canGo)
        {
            if (cmdCount == cmd.word.Length)
            {
                canGo = false;
                string reason = "Unable to reach the endpoint";
                FindObjectOfType<Loadlevel>().levelFailed(reason);
                return;
            }
            switch (cmd.word[cmdCount][0])
            {
                case "MOVE":
                    cmd.word[cmdCount][1] = mov.move(cmd.word[cmdCount][1], cmd.word[cmdCount][2]);
                    break;

                case "LASER":
                    las.options(cmd.word[cmdCount][1]);
                    break;

                case "USE":
                    if(use != null)
                    {
                        use();
                    }
                    else
                    {
                        Debug.Log("Something is Wrong");
                    }
                    break;
                default:
                    string reason = "Invalid Command:\n" + Commands.cmd[cmdCount];
                    FindObjectOfType<Loadlevel>().levelFailed(reason);
                    break;
            }

        }
    }
}
