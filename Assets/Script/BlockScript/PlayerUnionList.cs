using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class PlayerUnionList : MonoBehaviour
{
    // プレイヤーが持っている全てのブロックのリスト
    private readonly List<Block> blocks = new List<Block>();

    // プレイヤーにブロックを追加
    public void AddBlock(Block block)
    {
        blocks.Add(block);
    }

    // プレイヤーの全てのブロックを取得
    public List<Block> GetBlocks()
    {
        return blocks;
    }

    // プレイヤー自身の位置を取得
    public Vector3Int SelfPosition()
    {
        return Utility.ToVector3Int(transform.position);
    }



    // プレイヤーの前方向の位置を取得
    public Vector3Int GetForwardPosition()
    {
        var result = SelfPosition();
        for (int i = 0; i < blocks.Count; i++)
        {
            var position = Utility.ToVector3Int(blocks[i].transform.position);
            if (result.z < position.z)
            {
                result = position;
            }
        }
        return result;
    }

    // Playerの前方向の一番奥にある全てのブロックの取得
    public List<Block> GetForwardBlocks()
    {
        List<Block> result = new List<Block>();

        var fowardPosition = GetForwardPosition();
        for (int i = 0; i < blocks.Count; i++)
        {
            var position = Utility.ToVector3Int(blocks[i].transform.position);
            if (position.z == fowardPosition.z)
            {
                result.Add(blocks[i]);
            }
        }
        return result;
    }

    // プレイヤーの後方向の位置を取得
    public Vector3Int GetBackPosition()
    {
        var result = SelfPosition();
        for (int i = 0; i < blocks.Count; i++)
        {
            var position = Utility.ToVector3Int(blocks[i].transform.position);
            if (result.z > position.z)
            {
                result = position;
            }
        }
        return result;
    }

    // Playerの後ろ方向の一番奥にある全てのブロックの取得
    public List<Block> GetBackBlocks()
    {
        List<Block> result = new List<Block>();

        var backPosition = GetBackPosition();
        for (int i = 0; i < blocks.Count; i++)
        {
            var position = Utility.ToVector3Int(blocks[i].transform.position);
            if (position.z == backPosition.z)
            {
                result.Add(blocks[i]);
            }
        }
        return result;
    }

    // プレイヤーの右方向の位置を取得
    public Vector3Int GetRightPosition()
    {
        var result = SelfPosition();
        for (int i = 0; i < blocks.Count; i++)
        {
            var position = Utility.ToVector3Int(blocks[i].transform.position);
            if (result.x < position.x)
            {
                result = position;
            }
        }
        return result;
    }

    // Playerの右方向の一番奥にある全てのブロックの取得
    public List<Block> GetRightBlocks()
    {
        List<Block> result = new List<Block>();

        var rightPosition = GetRightPosition();
        for (int i = 0; i < blocks.Count; i++)
        {
            var position = Utility.ToVector3Int(blocks[i].transform.position);
            if (position.x == rightPosition.x)
            {
                result.Add(blocks[i]);
            }
        }
        return result;
    }



    // プレイヤーの左方向の位置を取得
    public Vector3Int GetLeftPosition()
    {
        var result = SelfPosition();
        for (int i = 0; i < blocks.Count; i++)
        {
            var position = Utility.ToVector3Int(blocks[i].transform.position);
            if (result.x > position.x)
            {
                result = position;
            }
        }
        return result;
    }

    // Playerの左方向の一番奥にある全てのブロックの取得
    public List<Block> GetLeftBlocks()
    {
        List<Block> result = new List<Block>();

        var leftPosition = GetLeftPosition();
        for (int i = 0; i < blocks.Count; i++)
        {
            var position = Utility.ToVector3Int(blocks[i].transform.position);
            if (position.x == leftPosition.x)
            {
                result.Add(blocks[i]);
            }
        }
        return result;
    }


    // プレイヤーの上方向の位置を取得
    public Vector3Int GetTopPosition()
    {
        var result = SelfPosition();
        for (int i = 0; i < blocks.Count; i++)
        {
            var position = Utility.ToVector3Int(blocks[i].transform.position);
            if (result.y < position.y)
            {
                result = position;
            }
        }
        return result;
    }

    // Playerの上方向の一番奥にある全てのブロックの取得
    public List<Block> GetTopBlocks()
    {
        List<Block> result = new List<Block>();

        var topPosition = GetTopPosition();
        for (int i = 0; i < blocks.Count; i++)
        {
            var position = Utility.ToVector3Int(blocks[i].transform.position);
            if (position.y == topPosition.y)
            {
                result.Add(blocks[i]);
            }
        }
        return result;
    }

    // プレイヤーの下方向の位置を取得
    public Vector3Int GetBottomPosition()
    {
        var result = SelfPosition();
        for (int i = 0; i < blocks.Count; i++)
        {
            var position = Utility.ToVector3Int(blocks[i].transform.position);
            if (result.y > position.y)
            {
                result = position;
            }
        }
        return result;
    }

    // Playerの下方向の一番奥にある全てのブロックの取得
    public List<Block> GetBottomBlocks()
    {
        List<Block> result = new List<Block>();

        var bottomPosition = GetBottomPosition();
        for (int i = 0; i < blocks.Count; i++)
        {
            var position = Utility.ToVector3Int(blocks[i].transform.position);
            if (position.y == bottomPosition.y)
            {
                result.Add(blocks[i]);
            }
        }
        return result;
    }

    // Playerの下方向の一番奥にある全てのブロックの取得part2
    public List<Block> GetBottomBlocks2()
    {
        List<Block> result = new List<Block>();

        for (int i = 0; i < blocks.Count; i++)
        {
            var targetposition = Utility.ToVector3Int(blocks[i].transform.position);
            if (targetposition.y == 0)
            {
                result.Add(blocks[i]);
            }
        }
        return result;
    }

    // プレイヤーの一番下の前方向の位置を取得
    public Vector3Int GetForwardBottomPosition()
    {
        Vector3Int result = Vector3Int.zero;
        var bottomblocks = GetBottomBlocks2();

        if (bottomblocks.Count == 0)
        {
            result = SelfPosition();
        }
        else
        {
            result = bottomblocks[0].Block_Position;
        }

        var selfposition = SelfPosition();
        if (selfposition.y == 0 && result.z < selfposition.z)
        {
            result = selfposition;
        }

        for (int i = 1; i < bottomblocks.Count; i++)
        {
            var position = Utility.ToVector3Int(bottomblocks[i].transform.position);
            if (result.z < position.z)
            {
                result = position;
            }
        }
        return result;
    }

    // プレイヤーの一番下の後方向の位置を取得
    public Vector3Int GetBackBottomPosition()
    {
        Vector3Int result = Vector3Int.zero;
        var bottomblocks = GetBottomBlocks2();

        if (bottomblocks.Count == 0)
        {
            result = SelfPosition();
        }
        else
        {
            result = bottomblocks[0].Block_Position;
        }

        var selfposition = SelfPosition();
        if (selfposition.y == 0 && result.z > selfposition.z)
        {
            result = selfposition;
        }

        for (int i = 1; i < bottomblocks.Count; i++)
        {
            var position = Utility.ToVector3Int(bottomblocks[i].transform.position);
            if (result.z > position.z)
            {
                result = position;
            }
        }
        return result;
    }

    // プレイヤーの一番下の右方向の位置を取得
    public Vector3Int GetRightBottomPosition()
    {
        Vector3Int result = Vector3Int.zero;
        var bottomblocks = GetBottomBlocks2();

        if (bottomblocks.Count == 0)
        {
            result = SelfPosition();
        }
        else
        {
            result = bottomblocks[0].Block_Position;
        }

        var selfposition = SelfPosition();
        if (selfposition.y == 0 && result.x < selfposition.x)
        {
            result = selfposition;
        }

        for (int i = 1; i < bottomblocks.Count; i++)
        {
            var position = Utility.ToVector3Int(bottomblocks[i].transform.position);
            if (result.x < position.x)
            {
                result = position;
            }
        }
        return result;
    }

    // プレイヤーの一番下の左方向の位置を取得
    public Vector3Int GetLeftBottomPosition()
    {
        Vector3Int result = Vector3Int.zero;
        var bottomblocks = GetBottomBlocks2();

        if (bottomblocks.Count == 0)
        {
            result = SelfPosition();
        }
        else
        {
            result = bottomblocks[0].Block_Position;
        }

        var selfposition = SelfPosition();
        if (selfposition.y == 0 && result.x > selfposition.x)
        {
            result = selfposition;
        }

        for (int i = 0; i < bottomblocks.Count; i++)
        {
            var position = Utility.ToVector3Int(bottomblocks[i].transform.position);
            if (result.x > position.x)
            {
                result = position;
            }
        }
        return result;
    }

    //ピボット前のブロックの数
    public int PivotForwardBlockCount()
    {
        var forwardpos = GetForwardPosition();
        var forwardbottompos = GetForwardBottomPosition();
        if (forwardpos.z <= forwardbottompos.z)
        {
            return 0;
        }
        var result = forwardpos.z - forwardbottompos.z;


        return Mathf.Abs(result) - 1;
    }

    //ピボット前の上のブロックの位置を取得
    public float PivotForwardTopPosition()
    {
        var forwardpos = GetForwardPosition();
        var forwardbottompos = GetForwardBottomPosition();
        if (forwardpos.z <= forwardbottompos.z)
        {
            return -0.5f;
        }
        var result = forwardpos.z - forwardbottompos.z;

        result = Mathf.Abs(result);

        return -0.5f + 1 * result;

    }

    //ピボット後のブロックの数
    public int PivotBackBlockCount()
    {
        var backpos = GetBackPosition();
        var backbottompos = GetBackBottomPosition();
        if (backpos.z >= backbottompos.z)
        {
            return 0;
        }
        var result = backpos.z - backbottompos.z;


        return Mathf.Abs(result) - 1;
    }

    //ピボット後の上のブロックの位置を取得
    public float PivotBackTopPosition()
    {
        var backpos = GetBackPosition();
        var backbottompos = GetBackBottomPosition();
        if (backpos.z >= backbottompos.z)
        {
            return -0.5f;
        }
        var result = backpos.z - backbottompos.z;

        result = Mathf.Abs(result);

        return -0.5f + 1 * result;

    }

    //ピボット右のブロックの数
    public int PivotRightBlockCount()
    {
        var rightpos = GetRightPosition();
        var rightbottompos = GetRightBottomPosition();
        if (rightpos.x <= rightbottompos.x)
        {
            return 0;
        }
        var result = rightpos.x - rightbottompos.x;


        return Mathf.Abs(result) - 1;
    }

    //ピボット右の上のブロックの位置を取得
    public float PivotRightTopPosition()
    {
        var rightpos = GetRightPosition();
        var rightbottompos = GetRightBottomPosition();
        if (rightpos.x <= rightbottompos.x)
        {
            return -0.5f;
        }
        var result = rightpos.x - rightbottompos.x;

        result = Mathf.Abs(result);

        return -0.5f + 1 * result;

    }

    //ピボット左のブロックの数
    public int PivotLeftBlockCount()
    {
        var leftpos = GetLeftPosition();
        var leftbottompos = GetLeftBottomPosition();
        if (leftpos.x >= leftbottompos.x)
        {
            return 0;
        }
        var result = leftpos.x - leftbottompos.x;


        return Mathf.Abs(result) - 1;
    }

    //ピボット左の上のブロックの位置を取得
    public float PivotLeftTopPosition()
    {
        var leftpos = GetLeftPosition();
        var leftbottompos = GetLeftBottomPosition();
        if (leftpos.x >= leftbottompos.x)
        {
            return -0.5f;
        }
        var result = leftpos.x - leftbottompos.x;

        result = Mathf.Abs(result);

        return -0.5f + 1 * result;

    }

    //ピボット前のブロックの数(L字移動用)
    public int PivotForwardBlockCount_LMove()
    {
        var forwardpos = GetForwardPosition();
        var forwardbottompos = GetForwardBottomPosition();
        if (forwardpos.z <= forwardbottompos.z)
        {
            return 0;
        }
        var result = forwardpos.z - forwardbottompos.z;


        return Mathf.Abs(result);
    }
    //ピボット後のブロックの数(L字移動用)
    public int PivotBackBlockCount_LMove()
    {
        var backpos = GetBackPosition();
        var backbottompos = GetBackBottomPosition();
        if (backpos.z >= backbottompos.z)
        {
            return 0;
        }
        var result = backpos.z - backbottompos.z;


        return Mathf.Abs(result);
    }
    //ピボット右のブロックの数(L字移動用)
    public int PivotRightblockCount_LMove()
    {
        var rightpos = GetRightPosition();
        var rightbottompos = GetRightBottomPosition();
        if (rightpos.x <= rightbottompos.x)
        {
            return 0;
        }
        var result = rightpos.x - rightbottompos.x;


        return Mathf.Abs(result);
    }
    //ピボット左のブロックの数(L字移動用)
    public int PivotLeftblockCount_LMove()
    {
        var leftpos = GetLeftPosition();
        var leftbottompos = GetLeftBottomPosition();
        if (leftpos.x >= leftbottompos.x)
        {
            return 0;
        }
        var result = leftpos.x - leftbottompos.x;


        return Mathf.Abs(result);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlayerUnionList))]
public class PlayerBlockListEditor : Editor
{
    private GUIStyle guiStyle = new GUIStyle();
    private PlayerUnionList playerBlockList = null;

    // このスクリプトを付けた GameObject を選択していると Scene ビューに情報を表示
    private void OnSceneGUI()
    {
        playerBlockList = (PlayerUnionList)target;

        var position = playerBlockList.SelfPosition();
        DrawLabel(position, string.Format("Self\n{0}", position), 0.1f, Color.red);

        DrawPosition("Forward", playerBlockList.GetForwardPosition());
        DrawPosition("Back", playerBlockList.GetBackPosition());
        DrawPosition("Right", playerBlockList.GetRightPosition());
        DrawPosition("Left", playerBlockList.GetLeftPosition());
        DrawPosition("Top", playerBlockList.GetTopPosition());
        DrawPosition("Bottom", playerBlockList.GetBottomPosition());
    }

    private void DrawPosition(string name, Vector3Int position)
    {
        if (playerBlockList.SelfPosition() != position)
        {
            DrawLabel(position, string.Format("{0}\n{1}", name, position), 0.1f, Color.red);
        }
    }

    private void DrawLabel(Vector3 position, string text, float fontSize, Color color)
    {
        var sceneCamera = SceneView.currentDrawingSceneView.camera;
        var cameraDistance = Vector3.Distance(sceneCamera.transform.position, position);
        guiStyle.normal.textColor = color;
        guiStyle.fontSize = (int)(fontSize * (512 / cameraDistance));
        Handles.Label(position, text, guiStyle);
    }
}
#endif

