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

    //
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

    //
    public bool BlockTypeCheck(Vector3Int position, Block.BLOCK_TYPE type)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].Block_Position == position &&
               blocks[i].GetBlock_Type == type)
            {
                return true;
            }
        }

        return false;
    }


    //
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

    //
    public Block GetBlock(Vector3Int position)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].Block_Position == position)
            {
                return blocks[i];
            }
        }

        return null;
    }

    //
    public Block GetBlock(Vector3Int position, Block.BLOCK_TYPE type)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].Block_Position == position &&
               blocks[i].GetBlock_Type == type)
            {
                return blocks[i];
            }
        }

        return null;
    }

}
