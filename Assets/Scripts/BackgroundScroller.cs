using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.002f;
    Material backgroundMaterial;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(backgroundScrollSpeed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        backgroundMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
