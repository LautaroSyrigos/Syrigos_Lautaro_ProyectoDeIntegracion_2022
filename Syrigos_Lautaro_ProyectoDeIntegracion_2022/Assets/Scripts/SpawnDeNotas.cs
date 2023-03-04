using UnityEngine;

public class SpawnDeNotas : MonoBehaviour
{
    public GameObject[] myObjects;
    private bool spawned = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !spawned)
        {
            for (int i = 0; i < myObjects.Length; i++)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-8, 10), 5, Random.Range(-8, 10));
                Instantiate(myObjects[i], randomSpawnPosition, Quaternion.identity);
            }
            spawned = true;
        }
    }


    /*
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
    }*/
}
