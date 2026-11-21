using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public GameObject EnemyPref;

    private float SpawnTime;
    private float SpawnBreake = 3f;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if(SpawnTime < Time.time)
        {
            SpawnTime = Time.time + SpawnBreake;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        if(SpawnBreake >= 0.5f)
        {
            SpawnBreake -= 0.005f;
        }
        float xx = Random.Range(15, 20);
        float yy = Random.Range(15, 20);

        int aa = Random.Range(1, 3);
        int bb = Random.Range(1, 3);

        if(aa == 1)
        {
            xx = -xx;
        }
        if(bb == 1)
        {
            yy = -yy;
        }

        Vector3 pos = new Vector3(xx, yy, 0);
        GameObject G = Instantiate(EnemyPref, pos, Quaternion.identity);
        G.transform.parent = this.transform;
    }
}
