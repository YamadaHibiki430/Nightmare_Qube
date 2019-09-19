using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCheck : MonoBehaviour
{

    //プレイヤーにくっついたブロックのリスト
    [SerializeField]
    private PlayerUnionList playerunion_list = null;

    // すべてのブロックの監視
    [SerializeField]
    private BlockManejar blockmanejar = null;

    //前に移動できるか
    bool ForwardMoveCheck()
    {
        var result = true;

        List<Block> fowardBlocks = playerunion_list.GetForwardBlocks();
        var forwardPos = playerunion_list.GetForwardPosition();
        var topPos = playerunion_list.GetTopPosition();
        var zMax = forwardPos.z + topPos.y;

        var count = playerunion_list.PivotForwardBlockCount_LMove();
        int addcount = count == 0 ? 1 : 0;

        if (fowardBlocks.Count > 0)
        {
            for (int i = 0; i < fowardBlocks.Count; i++)
            {
                //ユニオンの処理
                Vector3 pos = fowardBlocks[i].transform.position;
                var fowardPos = new Vector3(pos.x, 0.0f, pos.z + pos.y + addcount);
                var vector = Utility.ToVector3Int(fowardPos);

                var fowardPosDown = new Vector3(pos.x, -1.0f, zMax + addcount);
                var vectorDown = Utility.ToVector3Int(fowardPosDown);
                bool MoveCheckDown = blockmanejar.BlockCheck(vectorDown);

                if (!MoveCheckDown)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("下にブロックがないです");////
                }

                var block = (Union)blockmanejar.GetBlock<Block>(vector);
                if (block != null && block.is_union == false)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("ブロックがあります");
                }

                Vector3 pos2 = transform.position;
                var fowardPos2 = new Vector3(pos2.x, 0.0f, pos2.z + pos2.y + addcount);
                var vector2 = Utility.ToVector3Int(fowardPos2);
                var block2 = (Union)blockmanejar.GetBlock<Block>(vector2);
                if (block2 != null && block2.is_union == false)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("ブロックがあります");
                }
            }

            if (fowardBlocks[0].Block_Position.z == transform.position.z)
            {
                Vector3 pos2 = transform.position;
                var fowardPosDown2 = new Vector3(pos2.x, -1.0f, pos2.z + pos2.y + 1);
                var vectorDown2 = Utility.ToVector3Int(fowardPosDown2);
                bool MoveCheckDown2 = blockmanejar.BlockCheck(vectorDown2);
                if (!MoveCheckDown2)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("下にブロックがないです");/////
                }
            }
        }
        else
        {
            Vector3 pos2 = transform.position;
            var fowardPos2 = new Vector3(pos2.x, 0.0f, pos2.z + pos2.y + addcount);
            var vector2 = Utility.ToVector3Int(fowardPos2);

            var block2 = (Union)blockmanejar.GetBlock<Block>(vector2);
            if (block2 != null && block2.is_union == false)
            {
                result = false; // ブロックがあるので移動できない
                Debug.Log("ブロックがあります");
            }

            var fowardPosDown2 = new Vector3(pos2.x, -1.0f, pos2.z + pos2.y + 1);
            var vectorDown2 = Utility.ToVector3Int(fowardPosDown2);
            bool MoveCheckDown2 = blockmanejar.BlockCheck(vectorDown2);
            if (!MoveCheckDown2)
            {
                result = false; // ブロックがあるので移動できない
                Debug.Log("下にブロックがないです");
            }
        }
        return result;
    }

    //後ろに移動できるか
    bool BackMoveCheck()
    {
        var result = true;
        List<Block> backBlocks = playerunion_list.GetBackBlocks();
        var backpos = playerunion_list.GetBackPosition();
        var topPos = playerunion_list.GetTopPosition();
        var zMin = -(backpos.z - topPos.y);

        var count = playerunion_list.PivotBackBlockCount_LMove();
        int addcount = count == 0 ? 1 : 0;

        if (backBlocks.Count > 0)
        {

            for (int i = 0; i < backBlocks.Count; i++)
            {
                //ユニオンの処理
                Vector3 position = backBlocks[i].transform.position;
                var backPos = new Vector3(position.x, 0.0f, position.z - position.y - addcount);
                var vector = Utility.ToVector3Int(backPos);

                var backPosDown = new Vector3(position.x, -1.0f, -zMin - addcount);
                var vectorDown = Utility.ToVector3Int(backPosDown);
                bool MoveCheckDown = blockmanejar.BlockCheck(vectorDown);
                if (!MoveCheckDown)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("下にブロックがないです");
                }

                var block = (Union)blockmanejar.GetBlock<Block>(vector);
                if (block != null && block.is_union == false)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("ブロックがあります");
                }

                Vector3 pos2 = transform.position;
                var backPos2 = new Vector3(pos2.x, 0.0f, pos2.z - pos2.y - addcount);
                var vector2 = Utility.ToVector3Int(backPos2);
                var block2 = (Union)blockmanejar.GetBlock<Block>(vector2);
                if (block2 != null && block2.is_union == false)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("ブロックがあります");
                }

            }

            if (backBlocks[0].Block_Position.z == transform.position.z)
            {
                Vector3 pos3 = transform.position;
                var backPosDown2 = new Vector3(pos3.x, -1.0f, pos3.z - pos3.y - 1);
                var vectorDown2 = Utility.ToVector3Int(backPosDown2);
                bool MoveCheckDown2 = blockmanejar.BlockCheck(vectorDown2);
                if (!MoveCheckDown2)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("下にブロックがないです");
                }
            }
        }
        else
        {
            Vector3 pos2 = transform.position;
            var backPos2 = new Vector3(pos2.x, 0.0f, pos2.z - pos2.y - addcount);
            var vector2 = Utility.ToVector3Int(backPos2);

            var backPosDown2 = new Vector3(pos2.x, -1.0f, pos2.z - pos2.y - 1);
            var vectorDown2 = Utility.ToVector3Int(backPosDown2);
            bool MoveCheckDown2 = blockmanejar.BlockCheck(vectorDown2);
            if (!MoveCheckDown2)
            {
                result = false; // ブロックがあるので移動できない
                Debug.Log("下にブロックがないです");
            }

            var block2 = (Union)blockmanejar.GetBlock<Block>(vector2);
            if (block2 != null && block2.is_union == false)
            {
                result = false; // ブロックがあるので移動できない
                Debug.Log("ブロックがあります");
            }
        }
        return result;
    }

    //右に移動できるか
    bool RightMoveCheck()
    {
        var result = true;
        List<Block> rightBlocks = playerunion_list.GetRightBlocks();
        var rightpos = playerunion_list.GetRightPosition();
        var topPos = playerunion_list.GetTopPosition();
        var xMax = rightpos.x + topPos.y;

        var count = playerunion_list.PivotRightblockCount_LMove();
        int addcount = count == 0 ? 1 : 0;

        if (rightBlocks.Count > 0)
        {

            for (int i = 0; i < rightBlocks.Count; i++)
            {
                //ユニオンの処理
                Vector3 position = rightBlocks[i].transform.position;
                var rightPos = new Vector3(position.x + position.y + addcount, 0.0f, position.z);
                var vector = Utility.ToVector3Int(rightPos);
                var block = (Union)blockmanejar.GetBlock<Block>(vector);

                //移動方向の判定
                if (block != null && block.is_union == false)
                {
                    //ユニオンの判定
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("ブロックがあります");
                }
                //ユニオン下の処理
                var rightPosDown = new Vector3(xMax + addcount, -1.0f, position.z);
                var vectorDown = Utility.ToVector3Int(rightPosDown);
                bool MoveCheckDown = blockmanejar.BlockCheck(vectorDown);

                if (!MoveCheckDown)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("下にブロックがないです");
                }

                Vector3 pos2 = transform.position;
                var rightPos2 = new Vector3(pos2.x + pos2.y + addcount, 0.0f, pos2.z);
                var vector2 = Utility.ToVector3Int(rightPos2);
                var block2 = (Union)blockmanejar.GetBlock<Block>(vector2);
                if (block2 != null && block2.is_union == false)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("ブロックがあります");
                }


            }

            if (rightBlocks[0].Block_Position.x == transform.position.x)
            {
                Vector3 pos3 = transform.position;
                var rightPosDown2 = new Vector3(pos3.x + pos3.y + 1, -1.0f, pos3.z);
                var vectorDown2 = Utility.ToVector3Int(rightPosDown2);
                bool MoveCheckDown2 = blockmanejar.BlockCheck(vectorDown2);
                if (!MoveCheckDown2)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("下にブロックがないです");
                }
            }
        }
        else
        {
            Vector3 pos2 = transform.position;
            var rightPos2 = new Vector3(pos2.x + pos2.y + addcount, 0.0f, pos2.z);
            var vector2 = Utility.ToVector3Int(rightPos2);

            var rightPosDown2 = new Vector3(pos2.x + pos2.y + 1, -1.0f, pos2.z);
            var vectorDown2 = Utility.ToVector3Int(rightPosDown2);
            bool MoveCheckDown2 = blockmanejar.BlockCheck(vectorDown2);
            if (!MoveCheckDown2)
            {
                result = false; // ブロックがあるので移動できない
                Debug.Log("下にブロックがないです");
            }

            var block2 = (Union)blockmanejar.GetBlock<Block>(vector2);
            if (block2 != null && block2.is_union == false)
            {
                result = false; // ブロックがあるので移動できない
                Debug.Log("ブロックがあります");
            }
        }
        return result;
    }

    //左に移動できるか
    bool LeftMoveCheck()
    {
        var result = true;
        List<Block> leftBlocks = playerunion_list.GetLeftBlocks();
        var leftpos = playerunion_list.GetLeftPosition();
        var topPos = playerunion_list.GetTopPosition();
        var xMin = -(leftpos.x - topPos.y);

        var count = playerunion_list.PivotLeftblockCount_LMove();
        int addcount = count == 0 ? 1 : 0;

        if (leftBlocks.Count > 0)
        {

            for (int i = 0; i < leftBlocks.Count; i++)
            {
                //ユニオンの処理
                Vector3 position = leftBlocks[i].transform.position;
                var leftPos = new Vector3(position.x - position.y - addcount, 0.0f, position.z);
                var vector = Utility.ToVector3Int(leftPos);

                var leftPosDown = new Vector3(-xMin - addcount, -1.0f, position.z);
                var vectorDown = Utility.ToVector3Int(leftPosDown);
                bool MoveCheckDown = blockmanejar.BlockCheck(vectorDown);
                if (!MoveCheckDown)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("下にブロックがないです");
                }

                var block = (Union)blockmanejar.GetBlock<Block>(vector);
                if (block != null && block.is_union == false)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("ブロックがあります");
                }

                Vector3 pos2 = transform.position;
                var leftPos2 = new Vector3(pos2.x - pos2.y - addcount, 0.0f, pos2.z);
                var vector2 = Utility.ToVector3Int(leftPos2);

                var block2 = (Union)blockmanejar.GetBlock<Block>(vector2);
                if (block2 != null && block2.is_union == false)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("ブロックがあります");
                }

            }
            if (leftBlocks[0].Block_Position.x == transform.position.x)
            {
                Vector3 pos3 = transform.position;
                var leftPosDown2 = new Vector3(pos3.x - pos3.y - 1, -1.0f, pos3.z);
                var vectorDown2 = Utility.ToVector3Int(leftPosDown2);
                bool MoveCheckDown2 = blockmanejar.BlockCheck(vectorDown2);
                if (!MoveCheckDown2)
                {
                    result = false; // ブロックがあるので移動できない
                    Debug.Log("下にブロックがないです");
                }
            }
        }
        else
        {
            Vector3 pos2 = transform.position;
            var leftPos2 = new Vector3(pos2.x - pos2.y - addcount, 0.0f, pos2.z);
            var vector2 = Utility.ToVector3Int(leftPos2);

            var leftPosDown2 = new Vector3(pos2.x - pos2.y - 1, -1.0f, pos2.z);
            var vectorDown2 = Utility.ToVector3Int(leftPosDown2);
            bool MoveCheckDown2 = blockmanejar.BlockCheck(vectorDown2);
            if (!MoveCheckDown2)
            {
                result = false; // ブロックがあるので移動できない
                Debug.Log("下にブロックがないです");
            }

            var block2 = (Union)blockmanejar.GetBlock<Block>(vector2);
            if (block2 != null && block2.is_union == false)
            {
                result = false; // ブロックがあるので移動できない
                Debug.Log("ブロックがあります");
            }
        }
        return result;
    }

    // 移動できるか
    public bool Move_Check(Vector3 direction)
    {
        var result = false;

        if (direction == Vector3.forward)
        {
            result = ForwardMoveCheck();
        }
        if (direction == Vector3.back)
        {
            result = BackMoveCheck();
        }
        if (direction == Vector3.right)
        {
            result = RightMoveCheck();
        }
        if (direction == Vector3.left)
        {
            result = LeftMoveCheck();
        }
        return result;
    }

    //移動先の高さを取得
    private Vector3 SexyDynamiteMoveVector3(Vector3 direction)
    {
        var result = Vector3.zero;

        if (direction == Vector3.forward)
        {
            result.y = playerunion_list.GetForwardPosition().z - playerunion_list.GetBackPosition().z;
        }
        if (direction == Vector3.back)
        {
            result.y = playerunion_list.GetForwardPosition().z - playerunion_list.GetBackPosition().z;
        }
        if (direction == Vector3.right)
        {
            result.y = playerunion_list.GetRightPosition().x - playerunion_list.GetLeftPosition().x;
        }
        if (direction == Vector3.left)
        {
            result.y = playerunion_list.GetRightPosition().x - playerunion_list.GetLeftPosition().x;
        }
        return result;
    }
}
