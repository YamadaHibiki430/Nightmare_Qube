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
        foreach (Block block in blocks)
        {
            if (block.Block_Position == position)  { return true; }
        }


        return false;
    }

    //指定した座標のオブジェクト情報を取得
    public GameObject BlockObject(Vector3Int position, Block.BLOCK_TYPE type)
    {
        foreach (Block block in blocks)
        {
            if (block.Block_Position == position && 
                block.GetBlock_Type ==type) {
                return block.transform.gameObject;
            }
        }
        return null;
    }

    //指定した座標とタイプのブロックを取得する
    public Type GetBlock<Type>(Vector3Int position, Block.BLOCK_TYPE type = Block.BLOCK_TYPE.NONE)
        where Type : Block
    {
        foreach(Block block in blocks)
        {
            if(type == Block.BLOCK_TYPE.NONE) {
                if(block.Block_Position == position)
                {
                    return (Type)block;
                }
            }
            if (block.Block_Position == position &&
                block.GetBlock_Type == type)
            {
                return (Type)block;
            }
        }

        return null;
    }

}
