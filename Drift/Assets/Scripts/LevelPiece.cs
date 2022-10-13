using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelPiece : MonoBehaviour
{
    public float levelRotationChange;
    public Vector3 nextLevelCoordinate;
    public GameObject nextPiecePlacer;
    public LevelBuilderData builderData;
    private int lifeCycles = 5;
    public UnityEvent deathEvent;
    public UnityEvent InitializeEvent;

    private void Start()
    {
        builderData.UpdateNextCoordinates(nextPiecePlacer.transform.position);
        builderData.UpdateRotation(levelRotationChange);
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
