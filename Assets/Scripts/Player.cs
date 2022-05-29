using UnityEngine;

public class Player : MonoBehaviour
{
    // configuration parameters
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] float wingPower = 5f;
    [SerializeField] AudioClip flapSound;
    [SerializeField] [Range(0, 1)] float flapSoundVolume = 0.15f;


    [Header("Animation")]
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    // cache variables
    private GameManager gameManager;
    private Vector3 movement;
    private Vector3 playerPos;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // Fill cache
        gameManager = FindObjectOfType<GameManager>();
        playerPos = transform.position;
        SetUpFlightBoundaries();

        // Start the animation for the player.
        InvokeRepeating(nameof(AnimateWings), 0.07f, 0.07f);

        // Initial flight
        movement = Vector3.up * wingPower;
    }

    // Update is called once per frame
    void Update()
    {
        Flight();
    }

    private void SetUpFlightBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y - padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
    private void AnimateWings()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void Flight()
    {
        // Player input
        movement.x += Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            movement = Vector3.up * wingPower;
            AudioSource.PlayClipAtPoint(flapSound, Camera.main.transform.position, flapSoundVolume);
        }

        if (Input.GetButtonDown("Pause"))
        {
            gameManager.Pause();
        }

        // Flip player sprite horizontally if going left
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        // Affect player with the downward force.
        movement.y += gameManager.GetSinWeight() * Time.deltaTime;

        // Change player position.
        playerPos += movement * Time.deltaTime;
        playerPos.Set(Mathf.Clamp(playerPos.x, xMin, xMax), Mathf.Clamp(playerPos.y, yMin, yMax), 0);
        transform.position = playerPos;
   }
}
