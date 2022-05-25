using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        GameManager gameManager = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
        gameManager.Sin();
    }
}