using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
   
    void Start()
    {
        LeanTween.moveY(this.gameObject, 1.5f, 3).setLoopPingPong();
    }
}
