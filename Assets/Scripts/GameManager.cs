using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Config parameters
    [SerializeField] float weightOfSins = -9.8f; 
    [SerializeField] int placeInLine = 1000000;
    [SerializeField] bool paused = false;
    [SerializeField] TextMeshProUGUI pauseText;
    [SerializeField] float weightIncrease = 1.25f;
    [SerializeField] GameObject fadeOutObject;
    [SerializeField] AudioClip whispersSound;
    [SerializeField] [Range(0, 1)] float whispersSoundVolume = 0.15f;

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
        // Increase the weight and play whispers
        weightOfSins *= weightIncrease;
        AudioSource.PlayClipAtPoint(whispersSound, Camera.main.transform.position, whispersSoundVolume);

    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    // Pause/Unpause the game
    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0f;
            paused = true;
            pauseText.text = "Paused";
        }
        else
        {
            Time.timeScale = 1f;
            paused = false;
            pauseText.text = "";
        }
    }

    public void FadeToBlack()
    {
        StartCoroutine(FadeOut(true, 4));
    }

    public IEnumerator FadeOut(bool fadeToBlack, int fadeSpeed)
    {
        Color objectColor = fadeOutObject.GetComponent<Image>().color;
        float fadeAmount;


        if (fadeToBlack)
        {
            // Fade to black.
            while (objectColor.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadeOutObject.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        } 
        else
        {
            // Fade from black.
            while (objectColor.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadeOutObject.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
