using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;

public class UI_ResetButton : MonoBehaviour
{
    [SerializeField, TooltipAttribute("リセットボタン")]
    private Button m_resetButton;

    void Awake()
    {
        m_resetButton = GetComponent<Button>();
        m_resetButton.interactable = true;

        m_resetButton.OnClickAsObservable()
               .Subscribe(_ => {
                OnResetButton();
               }).AddTo(this.gameObject);
    }

    private void OnResetButton()
    {
        Debug.Log("◆UI_HomeButton : リセットボタンが押されました");
        m_resetButton.interactable = false;
        StartCoroutine(TransitionScreen.Instance.LoadSceneWait(SceneManager.GetActiveScene().name));
    }
}
