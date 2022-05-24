using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{
    Player player;
    private void OnTriggerEnter2D()
    {
        player = GameObject.FindObjectOfType(typeof(Player)) as Player;
        player.Sin();
    }
}
