using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        Player player = GameObject.FindObjectOfType(typeof(Player)) as Player;
        player.Sin();
    }
}