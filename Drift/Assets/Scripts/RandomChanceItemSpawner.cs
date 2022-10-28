using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChanceItemSpawner : RandomItemSpawner
{
    [SerializeField][Range(0,1)] private float chanceToSpawn;
    // Start is called before the first frame update
    protected override void Start()
    {
        if (Random.value <= chanceToSpawn)
        {
            SpawnThing();
        }
    }
}
