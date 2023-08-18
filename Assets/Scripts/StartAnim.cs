using UnityEngine;

public class StartAnim : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void startIt()
    {
        anim.SetBool("CanBegin", true);
    }
}
