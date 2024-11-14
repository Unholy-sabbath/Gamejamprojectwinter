using UnityEngine;

public class Penguin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpublic class Penguin : Enemy
    
    public class penguin : Enemy
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
}
