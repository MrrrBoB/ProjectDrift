using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadMillTrap : MonoBehaviour
{
    
    public GameObject[] hazardBeams;
    private WaitForSeconds wfs;
    public float beamInterval;
    private int randomRotation;
    private bool randomizeRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        randomRotation = Random.Range(0, 4) * 90;
        if(randomizeRotation)
            gameObject.transform.Rotate(0,randomRotation,0);
        wfs = new WaitForSeconds(beamInterval);
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        for (int i = 0; i < hazardBeams.Length; i++)
        {
            hazardBeams[i].SetActive(true);
            yield return wfs;
        }
    }
}
