using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class PlayerLeader : MonoBehaviour
{
    //フリック処理の読み込み
    [SerializeField] private Frick _frick;

    //プレイヤーの移動
    [SerializeField]
    private PlayerMove player_move = null;


    private void Start()
    {
        //フリックした方向に移動
        _frick.OnFricked.Subscribe(_direction =>
        {
            if (!player_move.GetIs_Move()) { player_move.Move(_direction); }
        });
    }

}
