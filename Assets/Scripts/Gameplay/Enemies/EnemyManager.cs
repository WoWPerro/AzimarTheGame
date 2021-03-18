using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> EnemyPrefabs;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", 0.5f);
    }

    void SpawnEnemy()
    {
        GameObject e = Instantiate(EnemyPrefabs[0], player.transform.position + new Vector3(Random.Range(3,10f),Random.Range(3,10f),0), Quaternion.identity);
        SecureSpawn(e, 0);
        Invoke("SpawnEnemy", Random.Range(2f,5f));
    }

    void SecureSpawn(GameObject g, int iterations)
    {
        if(iterations <= 5)
        {
            Collider[] hitColliders = Physics.OverlapSphere(g.transform.position, 5);
            if(hitColliders.Length > 1)
            {
                g.transform.position = player.transform.position - new Vector3(Random.Range(3,15f),Random.Range(3,15f),0);
                iterations++;
                SecureSpawn(g, iterations);
            }
        }
        else
        {
            Destroy(g);
        }
        
    }
}
