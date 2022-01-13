using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int laneNumber = 1;
    public int AmountOfHits;
    public GameObject lane01;
    public GameObject lane02;
    public GameObject lane03;
    public GameObject lane04;
    public GameObject selectedLane;
    public bool changingLane;
    public bool canMove;
    public int obstcaleBlock;
    public float distanceTotarget;

    public AudioSource carRunningAS;
    public AudioSource extraCarNoisesAS;
    public AudioClip CarHorn;
    public AudioClip tireScreech01;
    public AudioClip tireScreech02;

    public GameObject LeftFrontWheel;
    public GameObject RightFrontWheel;
    void Start()
    {
        selectedLane = lane02;
    }

    void Update()
    {

        if(canMove == true){
            if(changingLane == false){
                if (Input.GetButtonDown("Lane01") && selectedLane != lane01) {
                    selectedLane = lane01;
                    laneNumber = 1;
                    extraCarNoisesAS.PlayOneShot(tireScreech02);
                    changingLane = true;
                }

                if (Input.GetButtonDown("Lane02") && selectedLane != lane02) {
                    selectedLane = lane02;
                    laneNumber = 2;
                    extraCarNoisesAS.PlayOneShot(tireScreech01);
                    changingLane = true;
                }

                if (Input.GetButtonDown("Lane03") && selectedLane != lane03) {
                    selectedLane = lane03;
                    laneNumber = 3;
                    extraCarNoisesAS.PlayOneShot(tireScreech02);
                    changingLane = true;
                }

                if (Input.GetButtonDown("Lane04") && selectedLane != lane04) {
                    selectedLane = lane04;
                    laneNumber = 4;
                    extraCarNoisesAS.PlayOneShot(tireScreech01);
                    changingLane = true;
                }
            }

            MoveLanes(selectedLane);
        }

        if (Input.GetButtonDown("CarHorn")) {
            Debug.Log("CarHorn");
            extraCarNoisesAS.PlayOneShot(CarHorn);
        }
    }

    void MoveLanes(GameObject laneGameObject) {
        this.transform.position = Vector3.MoveTowards(this.transform.position,laneGameObject.transform.position,0.26f);
        if(changingLane == true) {
            distanceTotarget = Vector3.Distance(this.transform.position,selectedLane.transform.position);
            if(distanceTotarget < 0.5f) {
                changingLane = false;
            }
        }
    }

    /*public IEnumerator PlayerOutro() {
        yield return new WaitForSeconds(2.0f);
    }*/

    public IEnumerator PlayerIntro() {
        yield return new WaitForSeconds(2.0f);
    }
}
