using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;

public class BlockMerge : MonoBehaviour
{

    // すべてのブロックの監視
    [SerializeField]
    private BlockManejar blockmanejar = null;

    //プレイヤーにくっついたブロックのリスト
    [SerializeField]
    private PlayerUnionList playerunion_list = null;

 

    // ブロックをくっつける
    public void UnionBlockCheck()
    {
        UnionCheckAndSet(Utility.ToVector3Int(Vector3.forward) + Utility.ToVector3Int(transform.position));
        UnionCheckAndSet(Utility.ToVector3Int(Vector3.back) + Utility.ToVector3Int(transform.position));
        UnionCheckAndSet(Utility.ToVector3Int(Vector3.right) + Utility.ToVector3Int(transform.position));
        UnionCheckAndSet(Utility.ToVector3Int(Vector3.left) + Utility.ToVector3Int(transform.position));
        UnionCheckAndSet(Utility.ToVector3Int(Vector3.up) + Utility.ToVector3Int(transform.position));
        UnionCheckAndSet(Utility.ToVector3Int(Vector3.down) + Utility.ToVector3Int(transform.position));
    }

    // 再帰的にブロックをくっつける
    private void UnionCheckAndSet(Vector3Int vector)
    {
        var block = (Union)blockmanejar.GetBlock(vector, Block.BLOCK_TYPE.UINON);
        if (block == null) return; // Union 以外のブロックなら返す
        //Debug.Log("UnionCheckAndSet: " + vector + ", " + block.name);

        //合体
        if (!block.is_union)
        {
            block.transform.parent = transform;
            block.is_union = true;

            //透明化ブロックの場合消す
            if (blockmanejar.GetBlock(vector, Block.BLOCK_TYPE.GOST))
            {
                Material Cube = blockmanejar.BlockObject(vector, Block.BLOCK_TYPE.UINON).GetComponent<Renderer>().material;
                Sequence alphaseq = DOTween.Sequence();
                alphaseq.Append(DOTween.ToAlpha(() => Cube.color, color => Cube.color = color, 0.0f, 1.0f));
                Debug.Log("よばれた");

                //終了後の処理
                alphaseq.OnComplete(() =>
                {
                    Sequence seq = DOTween.Sequence();
                    //seq.Complete();
                    seq.Append(DOTween.ToAlpha(() => Cube.color, color => Cube.color = color, 0.0f, 3.0f));
                    seq.Append(DOTween.ToAlpha(() => Cube.color, color => Cube.color = color, 0.3f, 0.75f));
                    seq.Append(DOTween.ToAlpha(() => Cube.color, color => Cube.color = color, 0.0f, 0.75f));
                    seq.SetLoops(-1);
                });
            }

            //Playerblocklistに追加
            playerunion_list.AddBlock(block);
        }

        UnionCheckAndSet(new Vector3Int(vector.x - 1, vector.y, vector.z));
        UnionCheckAndSet(new Vector3Int(vector.x + 1, vector.y, vector.z));
        UnionCheckAndSet(new Vector3Int(vector.x, vector.y - 1, vector.z));
        UnionCheckAndSet(new Vector3Int(vector.x, vector.y + 1, vector.z));
        UnionCheckAndSet(new Vector3Int(vector.x, vector.y, vector.z - 1));
        UnionCheckAndSet(new Vector3Int(vector.x, vector.y, vector.z + 1));
    }


}
