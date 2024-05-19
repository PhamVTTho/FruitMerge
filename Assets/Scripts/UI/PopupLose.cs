using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PopupLose : MonoBehaviour
{
    public static PopupLose instance;
    public CanvasGroup _canvasGroup;
    public Button btnHome, btnReplay;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        btnHome.onClick.AddListener(GameManager.instance.BackHome);
        btnReplay.onClick.AddListener(GameManager.instance.ReTry);

    }
    public void Enable()
    {
        _canvasGroup.DOFade(1, 0.3f).OnComplete(() =>
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
