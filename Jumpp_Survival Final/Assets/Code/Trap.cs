using UnityEngine;

public class Trap : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Controller>().TakeDamage();
        }
    }
}
