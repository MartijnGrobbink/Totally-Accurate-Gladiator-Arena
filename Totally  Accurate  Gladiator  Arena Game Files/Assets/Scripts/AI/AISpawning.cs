using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawning : MonoBehaviour
{
    public List<GameObject> enemyPrefab;

    public GameObject prefabA;
    public GameObject prefabB;
    public GameObject prefabC;

    private GameObject spawnedA;
    private GameObject spawnedB;
    private GameObject spawnedC;


    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private List<GameObject> aiHolder;

    [SerializeField] private int spawnTimer = 10;
    [SerializeField] private int maxAmountAI = 3;
    private float etimer;
    private bool spawnPrefab;

    private void Update()
    {
        if (aiHolder.Count < maxAmountAI)
        {
            if (etimer < 0)
            {
                if (spawnedA == null)
                    SpawnAI(prefabA, spawnedA);
                else if (spawnedB == null)
                    SpawnAI(prefabB, spawnedB);
                else if (spawnedC == null)
                    SpawnAI(prefabC, spawnedC);
            }
            else
                etimer -= Time.deltaTime;
        }
    }


    //    private void Start()
    //    {
    //        SpawnAI(enemyPrefab[0]);
    //        etimer = spawnTimer;
    //    }

    //    private void Update()
    //    {
    //        if (aiHolder.Count < maxAmountAI)
    //        {
    //            if (etimer < 0)
    //                CheckWhatToSpawn();
    //            else
    //                etimer -= Time.deltaTime;
    //        }
    //    }

    //    private void CheckWhatToSpawn()
    //    {
    //        for (int i = 0; i < aiHolder.Count; i++)
    //        {
    //            Debug.Log("I =" + i);
    //            GameObject prefab = aiHolder[i];
    //            for (int b = 0; b < enemyPrefab.Count; b++)
    //            {
    //                Debug.Log(etimer);
    //                if (prefab == enemyPrefab[b])
    //                {
    //                    continue;
    //                }
    //                else if(spawnPrefab == false)
    //                {
    //                    SpawnAI(enemyPrefab[b + 1]);
    //                    spawnPrefab = true;
    //                    return;
    //                }
    //            }
    //        }
    //    }

    private void SpawnAI(GameObject prefab, GameObject spawnreference)
    {
        GameObject AI = Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
        if (spawnedA == null)
            spawnedA = AI;
        else if (spawnedB == null)
            spawnedB = AI;
        else if (spawnedC == null)
            spawnedC = AI;
        AIData data = AI.GetComponent<AIData>();
        data.teamBase = spawnPoint.transform;
        data.firstCrossing = spawnPoint.transform;
        aiHolder.Add(AI);

        etimer = spawnTimer;
        spawnPrefab = false;
    }
}
