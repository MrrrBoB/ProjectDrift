using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public void PlaceCharacterAt(Vector3 loc)
    {
        gameObject.transform.position = loc;
    }

    public void MoveCharacter(Vector3 mov)
    {
        gameObject.transform.position += mov;
    }
}
