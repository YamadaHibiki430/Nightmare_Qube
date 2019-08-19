using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;
using UnityEngine;

public class PlayerMove : PlayerLeader
{


    //移動スピード(標準値:1.0f)
    [SerializeField]
    private float MoveSpeed = 0.5f;

    //回転のピボットの情報
    private Transform pivot = null;


    private void Awake()
    {
        //Pivot自動生成
        GameObject pivotobj = new GameObject();
        pivot = pivotobj.transform;
    }


    public void Move(Vector3 direction)
    {

        var pivotPosition = Vector3.zero;

        var pivotmoveposition = Vector3.zero;

        // プレイヤーをピボットの子供にする
        transform.parent = pivot.transform;

        // 回転角度を決める
        var angle = pivot.eulerAngles;
        angle.x = Mathf.Round(direction.z * 90.0f);
        angle.z = Mathf.Round(direction.x * -90.0f);
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
}