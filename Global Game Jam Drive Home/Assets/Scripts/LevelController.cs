using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelController : MonoBehaviour
{
    public bool gameStart = false;
    public bool inCredits = false;
    public PlayerController PC;
    public GameObject creditsObjects;
    public GameObject menuObjects;
    public GameObject mainCanvas;
    public GameObject startButton;
    public GameObject creditsUIButton;
    public GameObject creditsUIBackButton;
    public RoadSpawnController RSC;
    public EventSystem ES;

    public GameObject EndingObjects;
    public GameObject MainCamera;

    public GameObject note01;
    public GameObject note02;
    public GameObject note03;
    void Start()
    {
        ES.SetSelectedGameObject(startButton);
    }

    public void StartGame(){
        Debug.Log("StartGame");
        PC.canMove = true;
        gameStart = true;
        mainCanvas.SetActive(false);
        StartCoroutine(RSC.TutorialTimer());
    }

    public void Credits() {
        if(inCredits == false){
            creditsUIButton.SetActive(false);
            creditsUIBackButton.SetActive(true);
            creditsObjects.SetActive(true);
            menuObjects.SetActive(false);
            inCredits = true;
        } else if(inCredits == true) {
            creditsUIButton.SetActive(true);
            creditsUIBackButton.SetActive(false);
            creditsObjects.SetActive(false);
            menuObjects.SetActive(true);
            inCredits = false;
        }
    }

    public IEnumerator GameEnd() {
        EndingObjects.SetActive(true);
        if(PC.AmountOfHits < 10) {
            note01.SetActive(true);
        } else if (PC.AmountOfHits > 10 && PC.AmountOfHits < 17) {
            note02.SetActive(true);
        } else if (PC.AmountOfHits > 17) {
            note03.SetActive(true);
        }
        PC.AmountOfHits = 0;
        yield return new WaitForSeconds(30.0f);
        note01.SetActive(false);
        note02.SetActive(false);
        note03.SetActive(false);
    }

    public void GameReset() {
        EndingObjects.SetActive(false);
        MainCamera.SetActive(true);
        mainCanvas.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
