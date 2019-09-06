using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Union : Block
{

    [System.NonSerialized]
    public bool is_union =false;

    public override BLOCK_TYPE GetBlock_Type
    {
        get
        {
            return BLOCK_TYPE.UINON;
        }
    }

}
