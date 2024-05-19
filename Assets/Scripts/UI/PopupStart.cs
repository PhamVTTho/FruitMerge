using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PopupStart : MonoBehaviour
{
    public Button btnPlay, howto;
    [SerializeField] Transform planHowto;

    private void Start()
    {
        btnPlay.onClick.AddListener(LoadScene);
        howto.onClick.AddListener(Enable);
    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Enable()
    {
        planHowto.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f);
    }

    public void Enable(CanvasGroup transform)
    {
        // transform.DOFade(1, 0f);
        // transform.transform.DOScale(1, 0.3f);
        transform.transform.DOMoveY(0, 0.7f).SetEase(Ease.InOutBack);
        transform.blocksRaycasts = true;
    }

    public void Close(CanvasGroup canvasGroup)
    {
        //canvasGroup.DOFade(0, 0.2f).OnComplete(() => { canvasGroup.transform.DOScale(0, 0f); });
        canvasGroup.transform.DOMoveY(10, 0.7f).SetEase(Ease.InOutBack);
    }
}