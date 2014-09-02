using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject[] obj;
    public float minHorizontal = -10f;
    public float maxHorizontal = 10f;
    public float minVertical = -10f;
    public float maxVertical = 10f;

    public float minSpawnTime= 1f;
    public float maxSpawnTime = 1f;

    void Start()
    {
        Invoke("SpawnNow", Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnNow()
    {
        Instantiate(obj[Random.Range(0,obj.Length)], transform.position + new Vector3(Random.Range(minHorizontal,maxHorizontal), Random.Range(minVertical,maxVertical)), Quaternion.identity);
		Invoke("SpawnNow", Random.Range(minSpawnTime, maxSpawnTime));
    }
}
