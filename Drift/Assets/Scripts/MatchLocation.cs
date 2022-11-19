using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchLocation : MonoBehaviour
{
    private Vector3 offSet;

    public GameObject matchObj;
    private float startingY;
    
    
    // Start is called before the first frame update
    void Start()
    {
        offSet = gameObject.transform.position - matchObj.transform.position;
        startingY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = matchObj.transform.position + offSet;

    }
}
