using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPieceController : MonoBehaviour
{
    public int roadPositionChoice;
    public GameObject[] roadPositionObjects;
    public Material testMaterial;
    public PlayerController PC;
    private float roadSpeed = 0f;
    public float roadSpeedindicator = 0f;
    //0.5f for speed SLOW
    //0.7f for speed STANDARD

    private void Start() {
        roadSpeed = 0.3f;
    }

    void Update()
    {

        switch (roadSpeedindicator) {
            case 1:
                roadSpeed = 0.3f;
                break;

            case 2:
                roadSpeed = 0.4f;
                break;

            case 3:
                roadSpeed = 0.5f;
                break;

            case 4:
                roadSpeed = 0.57f;
                break;
        }
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(0,0,-48), roadSpeed);

        if (this.transform.position.z <= -48) {
            this.transform.position = new Vector3(0, 0, 48);
            this.gameObject.SetActive(false);
            switch (roadPositionChoice) {
                case 0:
                    roadPositionObjects[0].GetComponent<RandomizedArraySpawner>().DisableObstacle(roadPositionChoice);
                    roadPositionObjects[0].SetActive(false);
                    
                    break;

                case 1:
                    roadPositionObjects[1].GetComponent<RandomizedArraySpawner>().DisableObstacle(roadPositionChoice);
                    roadPositionObjects[1].SetActive(false);
                    
                    break;

                case 2:
                    roadPositionObjects[2].GetComponent<RandomizedArraySpawner>().DisableObstacle(roadPositionChoice);
                    roadPositionObjects[2].SetActive(false);
                    
                    break;

                case 3:
                    roadPositionObjects[3].GetComponent<RandomizedArraySpawner>().DisableObstacle(roadPositionChoice);
                    roadPositionObjects[3].SetActive(false);
                    
                    break;
            }
        }
    }
    public void SpawnObstacle(){
    roadPositionChoice = Random.Range(0,4);
        switch (roadPositionChoice) {
            case 0:
                roadPositionObjects[0].SetActive(true);
                roadPositionObjects[0].GetComponent<RandomizedArraySpawner>().SpawnObstacle();
                break;

            case 1:
                roadPositionObjects[1].SetActive(true);
                roadPositionObjects[1].GetComponent<RandomizedArraySpawner>().SpawnObstacle();
                break;

            case 2:
                roadPositionObjects[2].SetActive(true);
                roadPositionObjects[2].GetComponent<RandomizedArraySpawner>().SpawnObstacle();
                break;

            case 3:
                roadPositionObjects[3].SetActive(true);
                roadPositionObjects[3].GetComponent<RandomizedArraySpawner>().SpawnObstacle();
                break;
        }
        //PC.obstcaleBlock = roadPositionChoice;
    }
}
