using UnityEngine;

public class SteeringManager : MonoBehaviour
{
    public SpriteRenderer northArrow;
    public SpriteRenderer eastArrow;
    public SpriteRenderer southArrow;
    public SpriteRenderer westArrow;
    private ArrowDirection _currentDir = ArrowDirection.North;
    private bool _hasActivatedAlreadyThisTurn = false;
    private void OnEnable()
    {
        Actions.OnGameStart += GameStart;
        Actions.OnTurnEnd += ResetActivation;
    }

    private void OnDisable()
    {
        Actions.OnGameStart -= GameStart;
        Actions.OnTurnEnd -= ResetActivation;
    }

    private void ResetActivation()
    {
        _hasActivatedAlreadyThisTurn = false;
    }
    private void GameStart()
    {
        ChangeArrow(ArrowDirection.North);
    }


    public void MoveCounterClockwise()
    {
        if (_hasActivatedAlreadyThisTurn)
            return;
        _hasActivatedAlreadyThisTurn = true;
        switch (_currentDir)
        {
            
            case ArrowDirection.North:
                ChangeArrow(ArrowDirection.West);
                break;
            case ArrowDirection.East:
                ChangeArrow(ArrowDirection.North);
                break;
            case ArrowDirection.South:
                ChangeArrow(ArrowDirection.East);
                break;
            case ArrowDirection.West:
                ChangeArrow(ArrowDirection.South);
                break;
        }
    }

    public void MoveClockwise()
    {
        if (_hasActivatedAlreadyThisTurn)
            return;
        _hasActivatedAlreadyThisTurn = true;
        switch (_currentDir)
        {
            case ArrowDirection.North:
                ChangeArrow(ArrowDirection.East);
                break;
            case ArrowDirection.East:
                ChangeArrow(ArrowDirection.South);
                break;
            case ArrowDirection.South:
                ChangeArrow(ArrowDirection.West);
                break;
            case ArrowDirection.West:
                ChangeArrow(ArrowDirection.North);
                break;
        }
    }
    private void ChangeArrow(ArrowDirection direction)
    {
        northArrow.color = Color.black;
        southArrow.color = Color.black;
        eastArrow.color = Color.black;
        westArrow.color = Color.black;
        
        switch (direction)
        {
            case ArrowDirection.North:
                northArrow.color = Color.red;
                _currentDir = ArrowDirection.North;
                break;
            case ArrowDirection.East:
                eastArrow.color = Color.red;
                _currentDir = ArrowDirection.East;
                break;
            case ArrowDirection.South:
                southArrow.color = Color.red;
                _currentDir = ArrowDirection.South;
                break;
            case ArrowDirection.West:
                westArrow.color = Color.red;
                _currentDir = ArrowDirection.West;
                break;
        }
        Debug.Log(_currentDir);
        //EMIT CURRENT DIR OUTWARD TO OTHER COMPONENTS
        Actions.OnUpdateArrowDirection(_currentDir);
       
    }
}

public enum ArrowDirection
{
    North,
    South,
    East,
    West,
}