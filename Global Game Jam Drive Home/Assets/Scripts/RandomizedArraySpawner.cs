using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedArraySpawner : MonoBehaviour
{
    public GameObject[] differentObstcles;
    public int randomChoice;
    void Start()
    {
        
    }

    public void SpawnObstacle(){
        randomChoice = Random.Range(0, 4);
        switch (randomChoice) {
            case 0:
                differentObstcles[0].SetActive(true);
                break;

            case 1:
                differentObstcles[1].SetActive(true);
                break;

            case 2:
                differentObstcles[2].SetActive(true);
                break;

            case 3:
                differentObstcles[3].SetActive(true);
                break;
        }
    }

    public void DisableObstacle(int numberChoice) {
        
        switch (randomChoice) {
            case 0:
                differentObstcles[0].SetActive(false);
                break;

            case 1:
                differentObstcles[1].SetActive(false);
                break;

            case 2:
                differentObstcles[2].SetActive(false);
                break;

            case 3:
                differentObstcles[3].SetActive(false);
                break;
        }
    }
}
