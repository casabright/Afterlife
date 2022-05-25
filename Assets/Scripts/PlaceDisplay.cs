using UnityEngine;
using TMPro;

public class PlaceDisplay : MonoBehaviour
{
    TextMeshProUGUI placeText;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        placeText = GetComponent<TextMeshProUGUI>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        placeText.text = "Place in Line: " + gameManager.GetPlaceInLine().ToString();
    }
}
