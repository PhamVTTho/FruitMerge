using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class Item : MonoBehaviour
{
    private Board _board;
    public int id;
    public SpriteRenderer _sprite;
    public Vector3Int cell;

    private void Start()
    {
        id = TargetManager.instance.id;
        _sprite.sprite = TargetManager.instance.arrTarget[id];
        transform.DOScale(1, 0.5f);
        _board = Board.instance;
    }

    public IEnumerator LevelUp()
    {
        id += 1;
        yield return new WaitForSeconds(0.7f);
        _sprite.sprite = TargetManager.instance.arrTarget[id];
        MathchesFinder.instance.DFS(cell.x, cell.y);
        MathchesFinder.instance.ClearVisited(cell.x, cell.y, Board.instance.posItem[cell.x, cell.y]);
    }

    public void MoveToTarget(Vector3 pos)
    {
        transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.2f).OnComplete(() =>
        {
            transform.DOMove(pos, 0.5f).OnComplete(() => Destroy(gameObject));
        });
    }
}