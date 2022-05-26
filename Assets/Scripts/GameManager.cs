using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] float weightOfSins = -9.8f; 
    [SerializeField] int placeInLine = 1000000;
    [SerializeField] bool paused = false;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameManagers = FindObjectsOfType<GameManager>().Length;
        if (numberGameManagers > 1)
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

    public float GetSinWeight()
    {
        return weightOfSins;
    }

    public void Sin()
    {
        weightOfSins *= 1.5f;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0f;
            paused = true;
        }
        else
        {
            Time.timeScale = 1f;
            paused = false;
        }
    }
}
