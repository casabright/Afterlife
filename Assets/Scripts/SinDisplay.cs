using UnityEngine;
using TMPro;

public class SinDisplay : MonoBehaviour
{
    TextMeshProUGUI sinText;
    GameSession gameSession;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        sinText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        sinText.text = "Weight of Sins: " + player.GetSinWeight().ToString();
    }
}
