using UnityEngine;
using TMPro;

public class PlaceDisplay : MonoBehaviour
{
    TextMeshProUGUI placeText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        placeText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        placeText.text = "Place in Line: " + gameSession.GetPlaceInLine().ToString();
    }
}
