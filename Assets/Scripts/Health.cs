using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class Health : MonoBehaviour
{
	[SerializeField] float maxHitPoints = 100f;
	float hitPoints;
    public float rawDamage;
	public Slider healthSlider;
public GameObject player;
float Healing = 10f;
	void Start()
	{
		hitPoints = maxHitPoints;
	}

	void Hit()
	{
		hitPoints -= rawDamage;
		SetHealthSlider();

		Debug.Log("OUCH: " + hitPoints.ToString());

		if (hitPoints <= 0)
		{
            hitPoints = 0;
            Die();
			
		}
	}
     private void OnCollisonEnter(Collision collision)
     {
		if (collision.gameObject.CompareTag("Enemy"))
        {
           Hit();
		}
     }
     
	void SetHealthSlider()
	{
		if (healthSlider != null)
		{
			healthSlider.value = NormalisedHitPoints();
		}
	}
private void OnTriggerEnter2D(Collider2D other)
{
if (other.CompareTag("Bed"))
{
    Heal();
}

}
	float NormalisedHitPoints()
	{
		return hitPoints / maxHitPoints;
	}
    void Die()
    {
        Debug.Log("player dead");
        Destroy(player);
    }
    void Heal()
    {
        hitPoints += Healing;
        if (hitPoints > maxHitPoints) hitPoints = maxHitPoints;
        SetHealthSlider();
    }
    }