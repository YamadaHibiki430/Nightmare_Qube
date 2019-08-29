using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System; // .NET 4.xモードで動かす場合は必須

public class Frick : MonoBehaviour
{
    private Vector3 _touchStartPos;
    private Vector3 _touchEndPos;
    private Subject<Vector3> _DirectionSubject = new Subject<Vector3>();

    //イベントの購読側だけを公開
    public IObservable<Vector3> OnFricked
    {
        get { return _DirectionSubject; }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _touchStartPos = Input.mousePosition;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {    
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _touchEndPos = Input.mousePosition;
            _DirectionSubject.OnNext(GetDirection());
        }
    }

    //フリック方向割り出し
    Vector3 GetDirection()
    {
        Vector3 vectorDirection = _touchEndPos - _touchStartPos;

        vectorDirection = Camera.main.transform.rotation * vectorDirection;

        float directionX = _touchEndPos.x - _touchStartPos.x;
        float directionY = _touchEndPos.y - _touchStartPos.y;

        var result = Vector3.zero;

        if (Mathf.Abs(vectorDirection.y) < Mathf.Abs(vectorDirection.x))
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
}
