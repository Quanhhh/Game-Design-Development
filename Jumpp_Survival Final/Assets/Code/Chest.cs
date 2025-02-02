using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator Animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered the chest");
        Animator.SetBool("IsOpen", true);
        Destroy(gameObject, 1.0f);
    }
}
