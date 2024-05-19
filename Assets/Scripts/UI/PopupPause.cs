using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopupPause : MonoBehaviour
{
    public CanvasGroup _canvasGroup;
    public Button btnHome, btnReplay, btnPlay, btnLevel;

    private void Start()
    {
        btnHome.onClick.AddListener(Home);
        btnReplay.onClick.AddListener(GameManager.instance.ReTry);
        btnPlay.onClick.AddListener(Play);
        btnLevel.onClick.AddListener(GameManager.instance.BackHome);
    }

    public void Play()
    {
        Time.timeScale = 1;
        Close();
    }

    public void Home()
    {
        GameManager.instance.BackHome();
    }

    public void Open()
    {
        transform.DOScale(1, 0.6f).SetUpdate(true).SetEase(Ease.Linear).OnComplete(() => { Time.timeScale = 0; });
    }

    public void Close()
    {
        transform.DOScale(0, 0.6f).SetUpdate(true).OnComplete(() => { Time.timeScale = 1; });
    }
}