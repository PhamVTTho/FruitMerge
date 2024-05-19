using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class TargetManager : MonoBehaviour
{
    public static TargetManager instance;
    public Image imgTarget;
    public Sprite[] arrTarget;
    public int id;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RandomID();
    }

    public void RandomID()
    {
        id = Random.Range(0, 3);
        imgTarget.transform.DOScale(0, 0.25f).OnComplete(() =>
        {
            imgTarget.sprite = arrTarget[id];
            imgTarget.SetNativeSize();
            imgTarget.transform.DOScale(1, 0.25f);
        });
    }
}