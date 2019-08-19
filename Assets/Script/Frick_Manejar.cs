using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frick_Manejar : MonoBehaviour
{
    //フリック判別用
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    private Vector3 BacktouchPos;
    private int touchCount = 0;

    //動かさないフラグ
    private bool RockMega = false;

    //↓【!!!!!!!!!必須!!!!!!!!!】操作性向上用先行入力用のバッファ(※!<削除禁止>!)↓
    Vector3 MoveBuffer;
    //↑【!!!!!!!!!必須!!!!!!!!!】操作性向上用先行入力用のバッファ(※!<削除禁止>!)↑

    //フリック判定
    public void Flick()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = Input.mousePosition;
            BacktouchPos = Input.mousePosition;
            touchCount = 0;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (BacktouchPos != Input.mousePosition) touchCount++;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = Input.mousePosition;
            if (!RockMega) MoveBuffer = GetDirection();
        }

        //Rock中は動かさず移動履歴も消す
        if (RockMega)
        {
            MoveBuffer = Vector3.zero;
            return;
        }

    }

    //フリック方向割り出し
    Vector3 GetDirection()
    {
        Vector3 vectorDirection = touchEndPos - touchStartPos;

        vectorDirection = Camera.main.transform.rotation * vectorDirection;
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;

        var result = Vector3.zero;

        if (Mathf.Abs(vectorDirection.y) < Mathf.Abs(vectorDirection.x * 1.2f))
        {
            if (directionX < 0)
            {
                result = Vector3.left;
            }
            else if (directionX > 0)
            {
                result = Vector3.right;
            }
        }
        else
        {
            if (directionY < 0)
            {
                result = Vector3.back;
            }
            else if (directionY > 0)
            {
                result = Vector3.forward;
            }
        }

        return result;
    }

    //Buffer初期化
    public void BufferReset()
    {
        MoveBuffer = Vector3.zero;
    }

}
