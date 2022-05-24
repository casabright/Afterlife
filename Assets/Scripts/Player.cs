using UnityEngine;

public class Player : MonoBehaviour
{
    // configuration parameters
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    private Vector3 movement;
    private Vector3 playerPos;
    public float weightOfSins = -9.8f;
    public float wingPower = 5f;

    [Header("Animation")]
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerPos = transform.position;
        SetUpFlightBoundaries();
        InvokeRepeating(nameof(AnimateWings), 0.07f, 0.07f);
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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1"))
        {
            movement = Vector3.up * wingPower;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                movement = Vector3.up * wingPower;
            }
        }
        movement.y += weightOfSins * Time.deltaTime;
        movement.x += Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        playerPos += movement * Time.deltaTime;
        playerPos.Set(Mathf.Clamp(playerPos.x, xMin, xMax), Mathf.Clamp(playerPos.y, yMin, yMax), 0);
        transform.position = playerPos;
   }

    internal object GetSinWeight()
    {
        return weightOfSins;
    }

    public void Sin()
    {
        weightOfSins *= 1.5f;

    }
}
