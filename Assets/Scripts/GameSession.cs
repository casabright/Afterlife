using UnityEngine;

public class GameSession : MonoBehaviour
{
    int placeInLine = 1000000;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetPlaceInLine()
    {
        return placeInLine;
    }

    public void MoveUpInLine(int placeValue)
    {
        placeInLine -= placeValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
