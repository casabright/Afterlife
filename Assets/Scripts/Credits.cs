using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    private Animator anim;  
    [SerializeField] GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ShowEndScreen()
    {
        gameObject.SetActive(false);
        endScreen.SetActive(true);
    }
}
