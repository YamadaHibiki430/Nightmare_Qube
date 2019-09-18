using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;
using UnityEngine;
using UniRx;

public class PlayerMove : MonoBehaviour
{
    //プレイヤーにくっついたブロックのリスト
    [SerializeField]
    private PlayerUnionList playerunion_list = null;

    //移動スピード(標準値:1.0f)
    [SerializeField]
    private float move_speed = 0.5f;

    //移動できるか判定クラス
    [SerializeField]
    private MoveCheck movecheck = null;

    //ブロックをくっつけるクラス
    [SerializeField]
    private BlockMerge blockmerge = null;

    //回転のピボットの情報
    private Transform pivot = null;

    //今動いているかどうか
    private bool is_move = false;


    private void Awake()
    {
        //Pivot自動生成
        GameObject pivotobj = new GameObject();
        pivot = pivotobj.transform;
    }

    //移動処理
    public void Move(Vector3 direction)
    {
        blockmerge.UnionBlockCheck();

        if (movecheck.Move_Check(direction))
        {
            var pivot_position = Vector3.zero;

            var pivotmove_position = Vector3.zero;

            is_move = true;

            // 水平方向のブロックの先端位置を取得
            if (direction == Vector3.forward)
            {
                var bottomPosition = playerunion_list.GetForwardBottomPosition();
                pivot_position = bottomPosition;
                pivot_position.z += 0.5f;
                pivot_position.y -= 0.5f;

                pivot.transform.position = pivot_position;
                pivotmove_position = pivot_position;
                pivotmove_position.z += playerunion_list.PivotForwardBlockCount();
                pivotmove_position.y = playerunion_list.PivotForwardTopPosition();
            }
            else if (direction == Vector3.back)
            {
                var bottomPosition = playerunion_list.GetBackBottomPosition();
                pivot_position = bottomPosition;
                pivot_position.z -= 0.5f;
                pivot_position.y -= 0.5f;

                pivot.transform.position = pivot_position;
                pivotmove_position = pivot_position;
                pivotmove_position.z -= playerunion_list.PivotBackBlockCount();
                pivotmove_position.y = playerunion_list.PivotBackTopPosition();
            }
            else if (direction == Vector3.right)
            {
                var bottomPosition = playerunion_list.GetRightBottomPosition();
                pivot_position = bottomPosition;
                pivot_position.x += 0.5f;
                pivot_position.y -= 0.5f;

                pivot.transform.position = pivot_position;
                pivotmove_position = pivot_position;
                pivotmove_position.x += playerunion_list.PivotRightBlockCount();
                pivotmove_position.y = playerunion_list.PivotRightTopPosition();
            }
            else if (direction == Vector3.left)
            {
                var bottomPosition = playerunion_list.GetLeftBottomPosition();
                pivot_position = bottomPosition;
                pivot_position.x -= 0.5f;
                pivot_position.y -= 0.5f;

                pivot.transform.position = pivot_position;
                pivotmove_position = pivot_position;
                pivotmove_position.x -= playerunion_list.PivotLeftBlockCount();
                pivotmove_position.y = playerunion_list.PivotLeftTopPosition();
            }

            // プレイヤーをピボットの子供にする
            transform.parent = pivot.transform;

            // 回転角度を決める
            var angle = pivot.eulerAngles;
            angle.x = Mathf.Round(direction.z * 90.0f);
            angle.z = Mathf.Round(direction.x * -90.0f);


            //ドットウィーンの宣言
            Sequence seq = DOTween.Sequence();

            // 自機回転
            seq.Join(
                pivot.transform.DORotate(angle, move_speed)
            );
            seq.Join(
                pivot.transform.DOMove(pivotmove_position, move_speed)
            );


            //移動終了後の処理
            seq.OnComplete(() =>
            {
                MoveEnd();
            });
        }
        else
        {
            is_move = true;
            var pivotPosition = Vector3.zero;

            // 水平方向のブロックの先端位置を取得
            if (direction == Vector3.forward)
            {
                pivotPosition = playerunion_list.GetForwardPosition();
                pivotPosition.z += 0.5f;
            }
            else if (direction == Vector3.back)
            {
                pivotPosition = playerunion_list.GetBackPosition();
                pivotPosition.z -= 0.5f;
            }
            else if (direction == Vector3.right)
            {
                pivotPosition = playerunion_list.GetRightPosition();
                pivotPosition.x += 0.5f;
            }
            else if (direction == Vector3.left)
            {
                pivotPosition = playerunion_list.GetLeftPosition();
                pivotPosition.x -= 0.5f;
            }

            // 下方向のブロックの位置を取得
            var bottomPosition = playerunion_list.GetBottomPosition();
            pivotPosition.y = bottomPosition.y;
            pivotPosition.y -= 0.5f;

            // ピボットの座標を反映
            pivot.transform.position = pivotPosition;

            // プレイヤーをピボットの子供にする
            transform.parent = pivot.transform;

            // 回転角度を決める
            var angle = pivot.eulerAngles;
            angle.x = Mathf.Round(direction.z * 10.0f);
            angle.z = Mathf.Round(direction.x * -10.0f);


            Sequence seq = DOTween.Sequence();
            //(1,1,1)に移動
            seq.Append(
                pivot.transform.DORotate(angle, move_speed)
            );
            seq.Append(
                pivot.transform.DORotate(Vector3.zero, move_speed)
            );
            //移動終了後の処理
            seq.OnComplete(() => {
                MoveEnd();
            });
        }
　　}

    //移動終了時の処理
    void MoveEnd()
    {
        //移動終了直後判定を立てる       
        transform.parent = null;

        var blocks = playerunion_list.GetBlocks();
        for (int i = 0; i < blocks.Count; i++)
        {
            Normailze(blocks[i].transform);
        }
        Normailze(transform);

        pivot.transform.rotation = Quaternion.identity;

        is_move = false;
    }

    // 移動後の正規化
    private void Normailze(Transform target)
    {
        Vector3 pos = Vector3.zero;
        pos.x = Mathf.Round(target.localPosition.x);
        pos.y = Mathf.Round(target.localPosition.y);
        pos.z = Mathf.Round(target.localPosition.z);
        target.localPosition = pos;

        Vector3 angles = Vector3.zero;
        angles.x = Mathf.Round(target.localEulerAngles.x);
        angles.y = Mathf.Round(target.localEulerAngles.y);
        angles.z = Mathf.Round(target.localEulerAngles.z);
        target.localEulerAngles = angles;

        Vector3 scale = Vector3.zero;
        scale.x = Mathf.Round(target.localScale.x);
        scale.y = Mathf.Round(target.localScale.y);
        scale.z = Mathf.Round(target.localScale.z);
        target.localScale = scale;
    }

    //デバッグ用
    private void OnDrawGizmos()
    {
        if (pivot == null) return;

        var color = Gizmos.color;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pivot.transform.position, 0.1f);
        Gizmos.color = color;
    }

    //動いてるかどうかの受け渡し
    public bool GetIs_Move()
    {
        return is_move;
    }
}