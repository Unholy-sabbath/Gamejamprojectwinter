using UnityEngine;

public class Fox : Enemy

{
    public new float speed = 15f;
    public new float health = 60f;

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
