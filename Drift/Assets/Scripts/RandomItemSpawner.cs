using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public GameObject[] listOfItems;

    private GameObject thisObject;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        SpawnThing();
    }

    // Update is called once per frame
    protected void SpawnThing()
    {
        if (listOfItems.Length > 0)
        {
            thisObject = Instantiate(listOfItems[Random.Range(0, listOfItems.Length)], gameObject.transform, true);
            thisObject.transform.rotation = gameObject.transform.parent.rotation;
            thisObject.transform.position = thisObject.transform.parent.position;
        }
    }
}
