using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;



public class PlayerLeader : MonoBehaviour
{
    // すべてのブロックの監視
    private BlockManejar blockmanejar = null;


    [SerializeField] private Frick _frick;

    //
    [SerializeField]
    private PlayerMove player_move = null;


    private void Start()
    {
        blockmanejar = GameObject.Find("BlockManejar").GetComponent<BlockManejar>();
        _frick.OnFricked.Subscribe(_direction =>
        {
            if (!player_move.Is_Move()) { player_move.Move(_direction); }
        });
    }

}
