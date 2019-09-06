using UnityEngine;
using UnityEngine.UI;

public class CanvasScalerController : MonoBehaviour {

    [SerializeField]
    private float m_width = 1080;
    [SerializeField]
    private float m_height = 1920;

    private void Start()
    {
        var scaler = GetComponent<CanvasScaler>();

        // 想定のアスペクト比と比べて画面比率が縦長だったら横合わせにする
        if (Screen.height / Screen.width > m_height / m_width)
        {
            scaler.matchWidthOrHeight = 0;
        }
    }
}
