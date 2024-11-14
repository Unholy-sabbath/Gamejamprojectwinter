using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public int damage;

    public Transform target;  
    protected Rigidbody2D rb;

    protected bool isDead = false;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player != null)
    {
        target = player.transform;
    }
      
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isDead) return;
        Movetowards();
    }
    protected virtual void Movetowards()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * speed;
    }

   public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0f)
        {
            Die();
        }
    }
  protected virtual void Die()
    {
        isDead = true;

        Destroy(gameObject);
    }
}
   /* public class Penguin : Enemy
    
    {
        public float speed = 3f;
        public float health = 100f;
    
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Die()
    {
        base.Die();
    }
    }
    */
public class Fox : Enemy

{
    public float speed = 15f;
    public float health = 60f;

protected override void Start()
{
    base.Start();
    }
    protected override void Update()
    {
        base.Update();
        }
        protected override void Die()
        {
            base.Die();
        }
}


public class Wollybearmoth : Enemy
{

     public float moveSpeed = 1.5f; 
     public float health = 300f;    

    protected override void Start()
    {
        base.Start();  
    }

    protected override void Update()
    {
        base.Update(); 
    }

    protected override void Die()
    {
        base.Die();
}
}