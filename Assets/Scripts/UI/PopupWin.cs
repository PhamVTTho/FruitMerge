using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PopupWin : MonoBehaviour
{
    public static PopupWin instance;
    public CanvasGroup _canvasGroup;
    public Button btnHome, btnReplay, btnNextLevel;
    public Text txtCoin;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        btnHome.onClick.AddListener(GameManager.instance.BackHome);
        btnReplay.onClick.AddListener(GameManager.instance.ReTry);
        btnNextLevel.onClick.AddListener(NextLevel);
    }
    public void NextLevel()
    {
        GameManager.instance.NexLevel();
        Close();
    }
    public void Enable()
    {
        txtCoin.text = PlayerPrefs.GetInt("Coin").ToString();
        _canvasGroup.DOFade(1, 0.3f).SetDelay(2).OnComplete(() =>
        {
            _canvasGroup.blocksRaycasts = true;
        });
    }
    public void Close()
    {
        _canvasGroup.DOFade(0, 0.3f).OnComplete(() =>
        {
            _canvasGroup.blocksRaycasts = false;
        });
    }
}
