using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System; // .NET 4.xモードで動かす場合は必須

public class MoveCount : MonoBehaviour
{
    [SerializeField]
    private IntReactiveProperty m_count = new IntReactiveProperty(0);
    
    public IObservable<int> OnCountChanged
    {
        get { return m_count; }
    }

    public void SetCount(int setnum)
    {
        m_count.Value = setnum;
    }
}
