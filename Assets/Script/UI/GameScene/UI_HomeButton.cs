using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;

public class UI_HomeButton : MonoBehaviour
{
    [SerializeField, TooltipAttribute("ホームボタン")]
    private Button _homeButton;

    void Awake()
    {
        _homeButton = GetComponent<Button>();

        _homeButton.OnClickAsObservable()
            .Subscribe(_ => {
                // ここに処理を書いたり、関数を呼んだりします
                this.OnHomeButton();
            }).AddTo(this.gameObject);
    }

    private void OnHomeButton()
    {
        Debug.Log("◆UI _HomeButton: ホームボタンが押されました");
    }

}
