using UnityEngine.XR.ARFoundation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private ARSession arSession;

    [SerializeField] private GameObject enemyPrefab;

    [Header("Enemy Settings")]
    [SerializeField] private int enemyCont = 1;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float despawnRate = 5f;

    private bool _gameStarted = false;

    //New
    private List<GameObject> _spawnedEnemies = new List<GameObject>();
    private int _score = 0;
    void Start()
    {
        arSession = FindFirstObjectByType<ARSession>();
        //Called from UI button
        UIManager.OnStartButtonPressed += StartGame;
        UIManager.OnRestartButtonPressed += RestartGame;
    }

    void StartGame()
    {
        if (_gameStarted) return;
        _gameStarted = true;
        print("Game started!!!");

        planeManager.enabled = false;
        foreach (var plane in planeManager.trackables)
        {
            var meshVisual = plane.GetComponent<ARPlaneMeshVisualizer>();
            if (meshVisual) meshVisual.enabled = false;

            var lineVisual = plane.GetComponent<LineRenderer>();
            if (lineVisual) lineVisual.enabled = false;
        }
    }

    void RestartGame()
    {
        _gameStarted = false;
        StartCoroutine(RestartGameCoroutine());
    }

    IEnumerator RestartGameCoroutine()
    {
        while (ARSession.state != ARSessionState.SessionTracking)
        {
            yield return null;
        }
        arSession.Reset();
        planeManager.enabled = true;
    }

    // Update is called once per frame

    void SpawnEnemy()
    {



    }


    IEnumerator SpawnEnemies()
    {
       




        yield return new WaitForSeconds(spawnRate);


    }

    IEnumerator DespawnEnemies(GameObject enemy)
    {
        yield return new WaitForSeconds(spawnRate);
        if (_spawnedEnemies.Contains(enemy))
        {
        

        }
    }
    



    void Update()
    {

    }
}


