using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Board : MonoBehaviour
{
    [SerializeField] private int _row;
    [SerializeField] private int _column;
    [SerializeField] private GameObject _cell;
    [SerializeField] private Chest _chest;
    [SerializeField] private GameObject _containerCells;
    [SerializeField] private GameObject _containerSwords;
    [SerializeField] private Spawner _spawner;

    private int _countFreeCells;
    private bool[,] _isFreeCells;

    public int Row => _row;
    public int Column => _column;
    public int CountFreeCells => _countFreeCells;
    public bool[,] IsFreeCells => _isFreeCells;

    private void OnDisable()
    {
        _chest.Placed -= OnPlaced;
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _isFreeCells = new bool[_column, _row];
        _countFreeCells = _isFreeCells.Length - 1;

        for(int i = 0; i < _row; i++)
        {
            for(int j = 0; j < _column; j++)
            {
                _spawner.Spawn(_cell, new Vector3(j, i, 1), _containerCells);
                _isFreeCells[j, i] = true;
            }
        }

        _chest = _spawner.Spawn(_chest.gameObject, new Vector3(_column / 2, _row / 2, -1)).GetComponent<Chest>();
        _chest.Placed += OnPlaced;
        _chest.Spawner = _spawner;
        _isFreeCells[_column / 2, _row / 2] = false;
    }

    private void OnPlaced(GameObject sword)
    { 
        int row = Random.Range(0, _row);
        int column = Random.Range(0, _column);

        while(_isFreeCells[column, row] == false)
        {
            row = Random.Range(0, _row);
            column = Random.Range(0, _column);
        }
            
        sword.transform.parent = _containerSwords.transform;
        _isFreeCells[column, row] = false;
        _countFreeCells--;
        SetObjectTo(sword, new Vector3(column, row, 0));                
    }

    public void SetObjectTo(GameObject gameObject, Vector3 point)
    {
        gameObject.transform.DOMove(point, 1f);
    }

    public void AddFreeCell()
    {
        _countFreeCells++;        
    }
}
