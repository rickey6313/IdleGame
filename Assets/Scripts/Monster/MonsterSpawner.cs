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
        
    void Start()
    {
        StartCoroutine(EnemyDropRoutine());
    }

    IEnumerator EnemyDropRoutine()
    {
        while(true)
        {
            while (spawnList.Count < enemyCount)
            {
                xPos = Random.Range(1, 50);
                zPos = Random.Range(1, 31);
                GameObject mob = Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
                Monster_Skeleton skel = mob.GetComponent<Monster_Skeleton>();
                skel.SetMonsterSpawner(this);
                yield return new WaitForSeconds(0.1f);
                spawnList.Add(mob);
            }
            yield return null;
        }
    }

    public void DestroyTarget(GameObject target)
    {
        GameObject find = spawnList.Find(x => x.GetInstanceID() == target.GetInstanceID());
        if(find)
        {
            spawnList.Remove(find);
            DestroyImmediate(target);
        }
        
    }
}

