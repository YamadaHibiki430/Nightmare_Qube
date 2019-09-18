using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManejar : MonoBehaviour
{
    [SerializeField]
    private Block[] blocks = null;

    private void Awake()
    {
        blocks = transform.GetComponentsInChildren<Block>();
    }

    //ブロックがあるかどうか
    public bool BlockCheck(Vector3Int position)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].Block_Position == position)
            {
                return true;
            }
        }

        return false;
    }

    //指定した座標のオブジェクト情報を取得
    public GameObject BlockObject(Vector3Int position, Block.BLOCK_TYPE type)
    {

        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].Block_Position == position &&
               blocks[i].GetBlock_Type == type)
            {
                return blocks[i].transform.gameObject;
            }
        }

        return null;
    }

    //指定した座標とタイプのブロックを取得する
    public Block GetBlock(Vector3Int position, Block.BLOCK_TYPE type = Block.BLOCK_TYPE.NONE)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if(type == Block.BLOCK_TYPE.NONE)
            {
                if (blocks[i].Block_Position == position)
                {
                    return blocks[i];
                }
            }
            if (blocks[i].Block_Position == position &&
               blocks[i].GetBlock_Type == type)
            {
                return blocks[i];
            }
        }

        return null;
    }

}
