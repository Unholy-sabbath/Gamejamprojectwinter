using UnityEngine;

public class Penguin : MonoBehaviour
{
    public float speed = 10f;
    public float health = 100f;
    public int damage = 10;

  /*  public Transform target;  
     Rigidbody2D rb;

     bool isDead = false;

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

     void Update()
    {
        if (target == null) return;  
        Movetowards();
    }

     void Movetowards()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * speed * Time.deltaTime;
    }
    */
    
    public Vector2 direction = Vector2.right;  

    void Update()
    {
        
        transform.Translate(direction * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);

            Destroy(collision.gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

     void Die()
    {
        Destroy(gameObject);
    }
}

