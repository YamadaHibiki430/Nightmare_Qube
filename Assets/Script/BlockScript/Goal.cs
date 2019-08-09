using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Block
{

    [System.NonSerialized]
    public bool is_goal;


    public override BLOCK_TYPE GetBlock_Type
    {
        get
        {
            return BLOCK_TYPE.GOAL;
        }
    }
}
