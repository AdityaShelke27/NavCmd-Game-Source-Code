using UnityEngine;

public class Detection : MonoBehaviour
{
    public TechInventory player;
    private void Awake()
    {
        player = GetComponent<TechInventory>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Environment")
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        player.enabled = false;
        FindObjectOfType<Loadlevel>().levelFailed("You collided with an object");
    }
}
