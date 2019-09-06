using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System; // .NET 4.xモードで動かす場合は必須


public class CountView : MonoBehaviour {

    [SerializeField] private MoveCount m_countView;

    [SerializeField] private Sprite[] m_images;

    [SerializeField] private Image m_number100;
    [SerializeField] private Image m_number10;
    [SerializeField] private Image m_number1;

    void Start()
    {
        m_countView.OnCountChanged.DistinctUntilChanged(). Subscribe(_count =>
        {
            ViewUpdate(_count);
        });
    }

    void ViewUpdate(int _nowNum)
    {
        int count100 = (_nowNum / 100) % 10;
        int count10 = (_nowNum / 10) % 10;
        int count1 = _nowNum % 10;

        m_number1.sprite = m_images[count1];
        m_number10.sprite = m_images[count10];
        m_number100.sprite = m_images[count100];

        //10以下の時は強制空白表示
        m_number10.gameObject.SetActive(_nowNum >= 10);
        m_number100.gameObject.SetActive(_nowNum >= 100);
    }
}
