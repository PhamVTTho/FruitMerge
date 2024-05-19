using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMain : MonoBehaviour
{
    public static UiMain instance;
    public Image aminScenen;

    public Button btnPause;
    public Text txtCoin;
    public PopupPause popupPause;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        btnPause.onClick.AddListener(Pause);

    }
    public void Pause()
    {
        popupPause.Open();
    }
    public void NexScene()
    {
        aminScenen.DOFade(1, 0.3f).OnComplete(() =>
        {
            aminScenen.DOFade(0, 0.3f);
        });
    }

    public void OpenPopup(CanvasGroup transform)
    {
        transform.DOFade(1, 0f).SetUpdate(true);
        transform.transform.DOScale(1, 0.3f).SetUpdate(true);
        transform.blocksRaycasts = true;
    }

    public void ClosePopup(CanvasGroup _canvasGroup)
    {
        _canvasGroup.DOFade(0, 0.3f).SetUpdate(true).OnComplete(() =>
        {
            transform.DOScale(0, 0f);
        });
        _canvasGroup.blocksRaycasts = false;

    }
}
