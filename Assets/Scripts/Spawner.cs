using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; 
    public Transform player;         
    public Transform spawner;         
    public float waveTime = 60f;      
    public float Baddiesperwave = 5; 
    private float lastwavetime;       
    private bool spawning = false;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastwavetime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        lastwavetime += Time.deltaTime;

        if (lastwavetime >= waveTime && !spawning)
        {
            spawning = true;
            SpawnWave();
            lastwavetime = 0f;
        }
    }

    void SpawnWave()
    {
        
        for (int i = 0; i < Baddiesperwave; i++)
        {
           
            GameObject enemyTospawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            
            Vector2 Spawnerpoint = (Vector2)spawner.position + new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));

            
            GameObject enemy = Instantiate(enemyTospawn, Spawnerpoint, Quaternion.identity);

            
            Enemy enemyScript = enemy.GetComponent<Enemy>();

            
            if (enemyScript != null)
            {
                
                enemyScript.SetTarget(player);
            }
        }

        
        spawning = false;
    }
}
