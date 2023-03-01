using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeNotas : MonoBehaviour
{
    public GameObject[] myObjects;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < myObjects.Length; i++)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-8, 10), 5, Random.Range(-8, 10));
                Instantiate(myObjects[i], randomSpawnPosition, Quaternion.identity);
            }
        }
    }


    //public GameObject cubePrefab;

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));
    //        Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
    //    }
    //}
}
