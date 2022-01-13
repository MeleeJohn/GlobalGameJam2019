using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoliageArraySpawner : MonoBehaviour
{

    public GameObject[] treeArray;
    public GameObject[] rockArray;
    public int randomChoice;
    public int loopRandomChoice;
    void Start()
    {
        ChooseRock();
        ChooseTree();
    }

    void ChooseTree() {
        loopRandomChoice = Random.Range(9,15);
        for (int i = 0; i<loopRandomChoice;i++){
            randomChoice = Random.Range(0, treeArray.Length);
            if(treeArray[randomChoice].activeSelf == true){
                randomChoice = Random.Range(0, treeArray.Length);
                treeArray[randomChoice].SetActive(true);
            } else {
                treeArray[randomChoice].SetActive(true);
            }
        }
    }

    void ChooseRock() {
        loopRandomChoice = Random.Range(3, 5);
        for (int i = 0; i < loopRandomChoice; i++) {
            randomChoice = Random.Range(0, rockArray.Length);
            if (rockArray[randomChoice].activeSelf == true) {
                randomChoice = Random.Range(0, rockArray.Length);
                rockArray[randomChoice].SetActive(true);
            } else {
                rockArray[randomChoice].SetActive(true);
            }
        }
    }

}
