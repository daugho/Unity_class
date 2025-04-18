using UnityEngine;

public class GravityPong : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player collided with GravityPong");
    }
}
