using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Cell : MonoBehaviour
{
    public Item _itemPrefab;
    public Vector3Int cell;
    public Sprite[] arrSprite;
    private SpriteRenderer _spriteRenderer;

    public void Init()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = arrSprite[Random.Range(0, arrSprite.Length)];
        transform.DOScale(1, 1f).SetEase(Ease.OutElastic);
    }

    private void OnMouseDown()
    {
        if (Board.instance.posItem[cell.x, cell.y] == null && GameManager.instance.isPlay)
        {
            GameManager.instance.CountStep();
            MathchesFinder.instance._listItem.Clear();
            Item newItem = Instantiate(_itemPrefab, transform.position, quaternion.identity);
            Board.instance.posItem[cell.x, cell.y] = newItem;
            newItem.cell = cell;
            StartCoroutine(GameManager.instance.CheckLose());
        }
    }

    private void OnMouseUp()
    {
        if (GameManager.instance.isPlay)
        {

            MathchesFinder.instance.DFS(cell.x, cell.y);
            TargetManager.instance.RandomID();
            MathchesFinder.instance.ClearVisited(cell.x, cell.y, Board.instance.posItem[cell.x, cell.y]);
        }
    }
}