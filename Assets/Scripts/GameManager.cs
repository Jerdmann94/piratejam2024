using NUnit.Framework.Internal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsGameStart = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Actions.OnGameStart();
        IsGameStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
