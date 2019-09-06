using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : ScriptableObject
{

    //Taget
    [SerializeField, Range(0, 999), TooltipAttribute("Taget手数")]
    private int _taget = 0; 



}
