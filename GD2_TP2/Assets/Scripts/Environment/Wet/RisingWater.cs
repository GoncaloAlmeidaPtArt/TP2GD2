using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingWater : MonoBehaviour
{
    [Header("Rising")]
    [SerializeField] private float minRiseSpeed = 1f;
    [SerializeField] private float maxRiseSpeed = 5f;
    [SerializeField] private float speedIncreaseRate = 0.1f;
    [SerializeField] private float maxX = 20f;

    [Header("Colors")]
    [SerializeField] private Color minSpeedColor = Color.white;
    [SerializeField] private Color midSpeedColor = Color.yellow;
    [SerializeField] private Color maxSpeedColor = Color.red;

    [Header("Scene")]
    [SerializeField] private string levelSceneName;

    private bool isRising = false;
    private float currentSpeed;
    private SpriteRenderer spriteRenderer;

    public void StartRising()
    {
        isRising = true;
    }

    public void ResetSpeed()
    {
        currentSpeed = minRiseSpeed;
        UpdateColor();
    }

    void Start()
    {
        currentSpeed = minRiseSpeed;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
            minSpeedColor = spriteRenderer.color;

        UpdateColor();
    }

    void Update()
    {
        if (!isRising) return;

        currentSpeed = Mathf.Min(currentSpeed + speedIncreaseRate * Time.deltaTime, maxRiseSpeed);

        transform.position += Vector3.right * currentSpeed * Time.deltaTime;

        if (transform.position.x >= maxX)
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);

        UpdateColor();
    }

    void UpdateColor()
    {
        if (spriteRenderer == null) return;

        // Normalize speed between 0 and 1
        float t = Mathf.InverseLerp(minRiseSpeed, maxRiseSpeed, currentSpeed);

        // First half: min color → yellow, second half: yellow → red
        Color newColor;
        if (t < 0.5f)
            newColor = Color.Lerp(minSpeedColor, midSpeedColor, t * 2f);
        else
            newColor = Color.Lerp(midSpeedColor, maxSpeedColor, (t - 0.5f) * 2f);

        spriteRenderer.color = newColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
            ResetLevel();
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(levelSceneName);
    }
}