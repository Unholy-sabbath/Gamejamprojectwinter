using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform spawner;
    public float waveTime = 60f;
    public float Baddiesperwave = 5;
    private float lastwavetime;
    private bool spawning = false;
    private bool firstwaveTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            GameObject enemyTospawn= enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            Vector2 Spawnerpoint = new Vector2(spawner.position.x, spawner.position.y) + new Vector2(Random.Range(-3f, 3f), Random.Range(-3,3f));

            Instantiate(enemyTospawn, Spawnerpoint, Quaternion.identity);
        }
        spawning = false;
    }
}
