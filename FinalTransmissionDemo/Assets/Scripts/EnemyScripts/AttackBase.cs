using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour {

    public int enemyNo;
    int LevelAggression;

    public GameObject enemyPrefab;

    public GameObject initialSpawnPoint;





    // Use this for initialization
    void Awake()
    {
        LevelAggression = Random.Range(0, 4);
        //Debug.Log(LevelAggression);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T)) // for testing purposes
        {
            DetermineAttack(LevelAggression);
        }
    }

    public void DetermineAttack(int aggressionLevel)
    {
        switch (aggressionLevel)
        {
            case 0:
                enemyNo = 4;
                GenerateAttackGroup(enemyNo, LevelAggression);
                Debug.Log(enemyNo);
                break;


            case 1:
                enemyNo = Random.Range(4, 7);
                GenerateAttackGroup(enemyNo, LevelAggression);
                Debug.Log(enemyNo);
                break;

            case 2:
                enemyNo = Random.Range(6, 10);
                GenerateAttackGroup(enemyNo, LevelAggression);
                Debug.Log(enemyNo);
                break;

            case 3:
                enemyNo = Random.Range(9, 12);
                GenerateAttackGroup(enemyNo, LevelAggression);
                Debug.Log(enemyNo);
                break;

            case 4:
                enemyNo = Random.Range(11, 14);
                GenerateAttackGroup(enemyNo, LevelAggression);
                Debug.Log(enemyNo);
                break;
        }
    }


    public void GenerateAttackGroup(int NumberOfEnemies, int enemyCount)
    {
        Vector3 spawnPosDistance = new Vector3(0, 0, 0);
        for (int i = 0; i < NumberOfEnemies; i++)
        {
            spawnPosDistance.z += enemyPrefab.transform.localScale.z * 1.5f;
            Instantiate(enemyPrefab, initialSpawnPoint.transform.position + spawnPosDistance, enemyPrefab.transform.rotation);
        }
    }


}//end script
