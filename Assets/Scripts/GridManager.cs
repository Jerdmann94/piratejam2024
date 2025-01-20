using System;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    public GameObject gridPrefab;
    public GameObject gridContainer;
    private GridType[,] _grid;
    private readonly int  _numCols = 4;
    private readonly int _numRows = 11;
    
    private void OnEnable()
    {
        Actions.OnGameStart += GameStart;
        Actions.OnUpdateArrowDirection += (ArrowDirection) => Debug.Log("OnUpdateArrowDirection");
    }

    private void OnDisable()
    {
        Actions.OnGameStart -= GameStart;
    }

    private void GameStart()
    {
        Debug.Log("Game started");
        InitGrid();
        Analytics.CustomEvent("GameStart from GridManager");
    }

    private void InitGrid()
    {
        _grid = new GridType[_numCols, _numRows];
        for (var index0 = 0; index0 < _grid.GetLength(0); index0++)
        for (var index1 = 0; index1 < _grid.GetLength(1); index1++)
        {
            var rand = Random.Range(0, 3);
            _grid[index0, index1] = (GridType)rand;
            SpawnGridSpace(_grid[index0, index1]);
        }
    }

    private void SpawnGridSpace(GridType gridType)
    {
        var image = Instantiate(gridPrefab, gridContainer.transform).GetComponent<Image>();
        image.color = GridTypeToColor(gridType);

    }

    private Color GridTypeToColor(GridType gridType)
    {
        switch (gridType)
        {
            case GridType.Empty:
                return Color.black;
                break;
            case GridType.Danger:
                return Color.red;
                break;
            case GridType.Planet:
                return Color.green;
                break;
        }

        //ERROR COLOR, ONLY SHOWS UP IF WE HAVE A PROBlEM
        return Color.magenta;
    }

    (int row, int col) SingleTo2D(int index)
    {
        return (index / _numCols, index % _numCols);
    }
     
     int TwoDToSingle(int row, int col)
    {
        return row * _numCols + col;
    }
}

public enum GridType
{
    Empty,
    Planet,
    Danger,
}
