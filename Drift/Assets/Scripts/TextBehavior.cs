using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBehavior : MonoBehaviour
{
    public TextMeshProUGUI tMesh;
    // Start is called before the first frame update
    public void UpdateText(string msg)
    {
        tMesh.text = msg;
    }

    public void UpdateText(FloatData dtObj)
    {
        tMesh.text = dtObj.GetNum().ToString("");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
