using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public enum BLOCK_TYPE
    {
        NONE,
        UINON,
        GOAL,
        KEY,
        KEYHOLE,
        GOST
    }

    //ブロックのポジション
    private Vector3Int position = Vector3Int.zero;

    //ブロックのポジションを返す
    public Vector3Int Block_Position
    {
        get
        {
            return position;
        }
    }

    //ブロックのタイプを返す
    public virtual BLOCK_TYPE GetBlock_Type
    {
        get
        {
            return BLOCK_TYPE.NONE;
        }
    }

    private void Update()
    {
        //ブロックのポジションを整数化
        position = Utility.ToVector3Int(transform.position);
    }
}
