using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MathchesFinder : MonoBehaviour
{
    public static MathchesFinder instance;
    public Board _board;
    public List<Item> _listItem = new List<Item>();
    private int[] dx = { -1, 0, 0, 1 };
    private int[] dy = { 0, -1, 1, 0 };
    public bool[,] visited = new bool[10, 10];


    private void Awake()
    {
        instance = this;
    }

    public void DFS(int x, int y)
    {

        visited[x, y] = true;

        int id = _board.posItem[x, y].id;
        for (int k = 0; k < 4; k++)
        {
            int xOther = x + dx[k];
            int YOther = y + dy[k];
            if (IsInside(xOther, YOther) && !visited[xOther, YOther])
            {
                if (_board.posItem[xOther, YOther] != null && _board.posItem[xOther, YOther].id == id)
                {
                    _listItem.Add(_board.posItem[xOther, YOther]);
                    DFS(xOther, YOther);
                }
            }

        }
    }

    private static bool IsInside(int xOther, int YOther)
    {
        return xOther >= 0 && xOther < 4 && YOther >= 0 && YOther < 6;
    }

    public void ClearVisited(int x, int y, Item currentItem)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                visited[i, j] = false;
            }
        }

        if (_listItem.Count >= 2)
        {

            Vector3 posMove = _board.posItem[x, y].transform.position;

            for (int i = _listItem.Count - 1; i >= 0; i--)
            {
                _board.posItem[_listItem[i].cell.x, _listItem[i].cell.y] = null;
                _listItem[i].MoveToTarget(posMove);
                _listItem.Remove(_board.posItem[_listItem[i].cell.x, _listItem[i].cell.y]);
                _listItem = _listItem.Where(Item => Item != null).ToList();


            }

            for (var j = _listItem.Count - 1; j > -1; j--)
            {
                if (_listItem == null)
                {
                    _listItem.RemoveAt(j);
                }
            }

            ScoreManager.instance.ChangeScore(_listItem.Count * 2);
            _listItem.Clear();
            StartCoroutine(currentItem.LevelUp());
            // DFS(x, y);
            // StartCoroutine(WaitTime(0.5f, () =>
            // {
            //     ResetVisited(x, y, Board.instance.posItem[x, y]);

            // }));
        }
    }

    public IEnumerator CrCallbackAction(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }
}