using System;
using UnityEngine;

public static class Actions
{
    public static Action OnGameStart;
    public static Action OnTurnEnd;
    public static Action<ArrowDirection> OnUpdateArrowDirection;
}
