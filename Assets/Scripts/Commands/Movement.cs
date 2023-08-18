using UnityEngine;
using System;
public class Movement : MonoBehaviour
{
    public int moveIter;
    public float speed;
    public float moveDist = 1;
    public TechInventory tech;
    float optspeed;
    float fdtime;
    private void Start()
    {
        tech = GetComponent<TechInventory>();       
        //fdtime = Time.fixedDeltaTime;
    }
    public string move(string iter,string str)
    {
        //Time.fixedDeltaTime = fdtime * Time.timeScale;
        optspeed = Time.fixedDeltaTime * speed * Time.timeScale;
        if (!int.TryParse(iter, out moveIter))
        {
            string reason = "Invalid Command:\n" + Commands.cmd[tech.cmdCount];
            FindObjectOfType<Loadlevel>().levelFailed(reason);
            return Convert.ToString(moveIter);
        }
        switch (str)
        {
            case "FORWARD":
                if (moveIter > 0)
                {
                    if (moveFwd())
                    {
                        return Convert.ToString(moveIter - 1);
                    }
                }
                else
                {
                    tech.cmdCount++;
                }
                break;
            case "BACKWARD":
                if (moveIter > 0)
                {
                    if (moveBkw())
                    {
                        return Convert.ToString(moveIter - 1);
                    }
                }
                else
                {
                    tech.cmdCount++;
                }
                break;
            case "LEFT":
                if (moveIter > 0)
                {
                    if (moveLeft())
                    {
                        return Convert.ToString(moveIter - 1);
                    }
                }
                else
                {
                    tech.cmdCount++;
                }
                break;
            case "RIGHT":
                if (moveIter > 0)
                {
                    if (moveRight())
                    {
                        return Convert.ToString(moveIter - 1);
                    }
                }
                else
                {
                    tech.cmdCount++;
                }
                break;
            default:
                string reason = "Invalid Command:\n" + Commands.cmd[tech.cmdCount];
                FindObjectOfType<Loadlevel>().levelFailed(reason);
                return Convert.ToString(moveIter);
        }

        return Convert.ToString(moveIter);
    }
    public bool moveFwd()
    {
        if (moveDist > 0)
        {
            Vector3 pos = transform.position + new Vector3(0, 0, 1);
            transform.LookAt(pos);
            transform.Translate(Vector3.forward * optspeed, Space.World);
            moveDist -= optspeed;
            return false;
        }
        else
        {
            moveDist = 1;
            return true;
        }

    }

    public bool moveBkw()
    {
        if (moveDist > 0)
        {
            Vector3 pos = transform.position + new Vector3(0, 0, -1);
            transform.LookAt(pos);
            transform.Translate(Vector3.back * optspeed, Space.World);
            moveDist -= optspeed;
            return false;
        }
        else
        {
            moveDist = 1;
            return true;
        }
    }

    public bool moveRight()
    {
        if (moveDist > 0)
        {
            Vector3 pos = transform.position + new Vector3(1, 0, 0);
            transform.LookAt(pos);
            transform.Translate(Vector3.right * optspeed, Space.World);
            moveDist -= optspeed;
            return false;
        }
        else
        {
            moveDist = 1;
            return true;
        }
    }

    public bool moveLeft()
    {
        if (moveDist > 0)
        {
            Vector3 pos = transform.position + new Vector3(-1, 0, 0);
            transform.LookAt(pos);
            transform.Translate(Vector3.left * optspeed, Space.World);
            moveDist -= optspeed;
            return false;
        }
        else
        {
            moveDist = 1;
            return true;
        }
    }
}
