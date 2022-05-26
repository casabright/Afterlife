using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 1f;
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");

    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameManager>().ResetGame();

    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitGameOver());
    }

    IEnumerator WaitGameOver()
    {
        yield return new WaitForSecondsRealtime(sceneLoadDelay);
        SceneManager.LoadScene("Game Over");
    }

    public void LoadHeaven()
    {
        StartCoroutine(WaitHeaven());
    }
    IEnumerator WaitHeaven()
    {
        yield return new WaitForSecondsRealtime(sceneLoadDelay);
        SceneManager.LoadScene("Heaven");
    }
  
    public void QuitGame()
    {
        Application.Quit();
    }

}
