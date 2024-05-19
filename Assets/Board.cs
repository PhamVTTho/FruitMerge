using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board instance;
    public int high, with;
    public Cell _CellPrefab;
    public float distance;

    public Item[,] posItem;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        posItem = new Item[with, high];

    }

    public void RenderMap()
    {
        for (int x = 0; x < with; x++)
        {
            for (int y = 0; y < high; y++)
            {
                Cell newCell = Instantiate(_CellPrefab, BienDoi(x, y), quaternion.identity, transform);
                newCell.cell = new Vector3Int(x, y, 0);
                posItem[x, y] = null;
            }
        }
        CapNhatOke();
        StartCoroutine(Amin());
    }

    public IEnumerator Amin()
    {
        yield return new WaitForSeconds(0.2f);
        foreach (Transform child in transform)
        {
            child.GetComponent<Cell>().Init();
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void CapNhatOke()
    {
        float x = (-distance * with) / 2;
        float y = (-distance * high) / 2;
        transform.position = new Vector3(x, y, 0);
    }

    public Vector2 BienDoi(int x, int y)
    {
        return new Vector2(distance * x, distance * y);
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying || posItem == null) return;
        for (int i = 0; i < posItem.GetLength(0); i++)
            for (int j = 0; j < posItem.GetLength(1); j++)
            {
                Gizmos.color = posItem[i, j] switch
                {
                    null => Color.white,
                    _ => Color.blue
                };

                Gizmos.DrawSphere(new Vector3(i * distance, j * distance), 0.1f);
            }
    }
}