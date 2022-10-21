using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class LevelPiece : MonoBehaviour
{
    private float levelRotationChange;
    public Vector3 nextLevelCoordinate;
    public GameObject[] PiecePlacers;
    [SerializeField]
    private GameObject nextPiecePlacer;
    public LevelBuilderData builderData;
    private int lifeCycles = 3;
    public UnityEvent deathEvent;
    public UnityEvent InitializeEvent;
    private GameObject currentTrap;
    

    protected void Start()
    {
        nextPiecePlacer = PiecePlacers[Random.Range(0, PiecePlacers.Length)];
        levelRotationChange = nextPiecePlacer.transform.localEulerAngles.y;
        nextLevelCoordinate = nextPiecePlacer.transform.position;
        builderData.UpdateNextCoordinates(nextLevelCoordinate);
        builderData.UpdateRotation(levelRotationChange);
        Debug.Log(levelRotationChange);
    }

    public void PassCycle()
    {
        lifeCycles -= 1;
        if (lifeCycles <= 0)
        {
            deathEvent.Invoke();
            Destroy(gameObject);
        }
    }

    public void Initialize()
    {
        InitializeEvent.Invoke();
    }
}
