using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public int damage;

    public Transform target;  
    protected Rigidbody2D rb;

    protected bool isDead = false;

    
    
  protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    protected virtual void Update()
    {
        if (target == null) return;  
        Movetowards();
    }

    protected virtual void Movetowards()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * speed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
   



