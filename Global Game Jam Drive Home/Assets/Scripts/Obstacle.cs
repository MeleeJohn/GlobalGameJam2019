using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType {PotHole, Constuction, SlowDriver, Animal};

public class Obstacle : MonoBehaviour
{
    public ObstacleType OT;
    public AudioSource AS;
    public GameObject player;
    public GameObject[] laneObjects;
    public PlayerController PC;
    public float distanceToPlayer;
    public bool changingLane;
    public int laneNumber;
    public RoadPieceController roadPieceController;
    public GameObject[] Barricades;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        PC = player.GetComponent<PlayerController>();
        
    }

    public void Update() {
        //roadPieceController = transform.parent.gameObject.GetComponent<RoadPieceController>();
        //laneNumber = roadPieceController.roadPositionChoice;
        if (OT == ObstacleType.SlowDriver) {
            distanceToPlayer = Vector3.Distance(this.transform.position,player.transform.position);
            if(distanceToPlayer < 15f && laneNumber == PC.laneNumber) {
                //carMove = true;
                //StartCoroutine(CarMove());
                CarMove();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            AS.PlayOneShot(AS.clip);
            other.gameObject.GetComponent<PlayerController>().AmountOfHits++;
            Debug.Log("Hit the Player");
        }
        /*if(OT == ObstacleType.Constuction) {
            StartCoroutine(ResetBarricades());
        }*/
    }

    private void CarMove() {

        switch (laneNumber) {

            case 1:
                this.transform.position = Vector3.MoveTowards(this.transform.position, laneObjects[2].transform.position, 0.20f);
                if (changingLane == true) {
                    float distanceToTarget = Vector3.Distance(this.transform.position, laneObjects[2].transform.position);
                    if (distanceToTarget < 0.5f) {
                        changingLane = false;
                    }
                }
                break;

            case 2:
                this.transform.position = Vector3.MoveTowards(this.transform.position, laneObjects[3].transform.position, 0.20f);
                if (changingLane == true) {
                    float distanceToTarget = Vector3.Distance(this.transform.position, laneObjects[3].transform.position);
                    if (distanceToTarget < 0.5f) {
                        changingLane = false;
                    }
                }
                break;

            case 3:
                this.transform.position = Vector3.MoveTowards(this.transform.position, laneObjects[0].transform.position, 0.20f);
                if (changingLane == true) {
                    float distanceToTarget = Vector3.Distance(this.transform.position, laneObjects[0].transform.position);
                    if (distanceToTarget < 0.5f) {
                        changingLane = false;
                    }
                }
                break;

            case 4:
                this.transform.position = Vector3.MoveTowards(this.transform.position, laneObjects[1].transform.position, 0.20f);
                if (changingLane == true) {
                    float distanceToTarget = Vector3.Distance(this.transform.position, laneObjects[1].transform.position);
                    if (distanceToTarget < 0.5f) {
                        changingLane = false;
                    }
                }
                break;
        }
    }

    public IEnumerator ResetBarricades() {
        yield return new WaitForSeconds(0.15f);
        for(int i = 0; i< Barricades.Length; i++) {
            Barricades[i].transform.position = new Vector3(0, 0.24f, -1.92f);
            Barricades[i].transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
