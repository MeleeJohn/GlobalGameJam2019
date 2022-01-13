using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnController : MonoBehaviour
{
    public GameObject justSentRoadPiece;
    public GameObject RoadPieceSpawnReference;
    public GameObject[] roadPieces;
    public int roadCount = 0;
    public int obstacleSpacer = 3;
    public int obstacleSpacerBase;
    public float roadDistance;
    private bool checkDistance;
    public bool tutorialArea;
    public float roadDistanceFromSpawn = 24f;
    public float roadSpeedSpawner = 1f;
    //24f for distance SLOW
    //25f for distance STANDARD
    public LevelController levelController;
    public PlayerController PC;
    public Animator musicAnim;
    public AudioSource mainMenuAS;
    public AudioSource mainMusicAS;
    public AudioSource tutorialMusicAS;
    void Start()
    {
        RoadPieceSpawnReference = this.gameObject;
        SpawnRoadPiece();
        mainMenuAS.Play();
    }

    void Update()
    {
        if(checkDistance == true){
            if (justSentRoadPiece.transform.position.z <= roadDistanceFromSpawn) {
                SpawnRoadPiece();
            }
        }
    }

    void SpawnRoadPiece() {
        roadPieces[roadCount].SetActive(true);
        justSentRoadPiece = roadPieces[roadCount];
        checkDistance = true;

        roadPieces[roadCount].GetComponent<RoadPieceController>().roadSpeedindicator = roadSpeedSpawner;
        if(levelController.gameStart == true){
            if (obstacleSpacer > 0) {
                obstacleSpacer--;
            } else if (obstacleSpacer <= 0) {
                roadPieces[roadCount].GetComponent<RoadPieceController>().SpawnObstacle();
                obstacleSpacer = obstacleSpacerBase;
            }
        }

        if (roadCount == 9){
            roadCount=0;
        } else {
            roadCount++;
        }
    }

    public IEnumerator TutorialTimer() {
        musicAnim.SetBool("FadeIntoTutorialMusic", true);
        musicAnim.SetBool("FadeIntoMainMenuMusic", false);
        mainMenuAS.Stop();
        tutorialMusicAS.Play();
        roadDistanceFromSpawn = 24.5f;
        roadSpeedSpawner = 1f;
        obstacleSpacerBase = 1;
        obstacleSpacer = obstacleSpacerBase;
        yield return new WaitForSecondsRealtime(30.0f); // 30.0fs
        tutorialArea = false;
        roadDistanceFromSpawn = 24.65f;
        roadSpeedSpawner = 2f;
        obstacleSpacerBase = 0;
        musicAnim.SetBool("FadeIntoMainMusic",true);
        musicAnim.SetBool("FadeIntoTutorialMusic", false);
        mainMusicAS.Play();
        mainMenuAS.Stop();
        obstacleSpacer = obstacleSpacerBase;
        StartCoroutine(GameTimer());
    }

    public IEnumerator GameTimer() {
        yield return new WaitForSecondsRealtime(61.0f); // 61.0f
        roadDistanceFromSpawn = 25f;
        roadSpeedSpawner = 3f;
        obstacleSpacerBase = 0;
        obstacleSpacer = obstacleSpacerBase;
        yield return new WaitForSecondsRealtime(66.0f); // 66.0f
        roadDistanceFromSpawn = 25.2f;
        roadSpeedSpawner = 4f;
        obstacleSpacerBase = 0;
        obstacleSpacer = obstacleSpacerBase;
        yield return new WaitForSecondsRealtime(40.0f); // 40.0f
        levelController.gameStart = false;
        StartCoroutine(GameEnd());
    }

    public IEnumerator GameEnd() {
        //PC.canMove = false;
        StartCoroutine(levelController.GameEnd());
        roadDistanceFromSpawn = 24.5f;
        roadSpeedSpawner = 1f;
        obstacleSpacerBase = 1;
        obstacleSpacer = obstacleSpacerBase;
        yield return new WaitForSecondsRealtime(30.0f);
        RoadReset();
        musicAnim.SetBool("FadeIntoMainMenuMusic", true);
        musicAnim.SetBool("FadeIntoMainMusic", false);
        mainMusicAS.Stop();
        mainMenuAS.Stop();
        tutorialMusicAS.Stop();
        mainMenuAS.Play();
    }

    public void RoadReset() {
        levelController.GameReset();
    }
}
