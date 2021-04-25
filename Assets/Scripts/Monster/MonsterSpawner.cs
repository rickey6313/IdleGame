using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int currentCount;
    public int enemyCount;
    public List<GameObject> spawnList = new List<GameObject>();
    private Queue<GameObject> hideQueue = new Queue<GameObject>();
    private WaitForSeconds onSec = new WaitForSeconds(1.0f);

    void Start()
    {
        SpawnEnemy();
        StartCoroutine(EnemyDropRoutine());
    }

    private void SpawnEnemy()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            xPos = Random.Range(1, 50);
            zPos = Random.Range(1, 31);
            GameObject mob = Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            Monster_Skeleton skel = mob.GetComponent<Monster_Skeleton>();
            skel.SetMonsterSpawner(this);
            spawnList.Add(mob);
            skel.Init();
        }
    }

    IEnumerator EnemyDropRoutine()
    {
        while(true)
        {
            while (hideQueue.Count > 0)
            {
                xPos = Random.Range(1, 50);
                zPos = Random.Range(1, 31);
                
                GameObject mob = hideQueue.Dequeue();
                Monster_Skeleton skel = mob.GetComponent<Monster_Skeleton>();

                skel.transform.position = new Vector3(xPos, 0, zPos);
                skel.Init();
                yield return new WaitForSeconds(0.1f);                
            }
            yield return onSec;
        }
    }

    public void HideTarget(GameObject target)
    {
        hideQueue.Enqueue(target);        
    }
}

