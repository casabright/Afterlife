using UnityEngine;
using TMPro;

public class SinDisplay : MonoBehaviour
{
    TextMeshProUGUI sinText;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        sinText = GetComponent<TextMeshProUGUI>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        sinText.text = "Weight of Sins: " + gameManager.GetSinWeight().ToString();
    }
}
