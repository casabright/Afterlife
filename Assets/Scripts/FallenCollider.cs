using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<SceneLoader>().LoadGameOver();
        Destroy(collision.gameObject);
    }
}
