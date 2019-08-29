using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Test_Frickview : MonoBehaviour
{
    [SerializeField] private Frick _frick;

    // Start is called before the first frame update
    void Start()
    {
        _frick.OnFricked.Subscribe(_direction => 
        {
            Debug.Log("Frickview:フリック方向:" + _direction);
        });
    }
}
