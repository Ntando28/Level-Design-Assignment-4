using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public Transform CamPos;
   

    // Update is called once per frame
    void Update()
    {
        transform.position = CamPos.position;
    }
}
