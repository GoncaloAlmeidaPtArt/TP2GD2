using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingWater : MonoBehaviour
{
    [Header("Rising")]
    [SerializeField] private float minRiseSpeed = 1f;
    [SerializeField] private float maxRiseSpeed = 5f;
    [SerializeField] private float speedIncreaseRate = 0.1f;
    [SerializeField] private float maxX = 20f;

    [Header("Scene")]
    [SerializeField] private string levelSceneName;

    private bool isRising = false;
    private float currentSpeed;

    public void StartRising()
    {
        isRising = true;
    }

    public void ResetSpeed()
    {
        currentSpeed = minRiseSpeed;
    }

    void Start()
    {
        currentSpeed = minRiseSpeed;
    }

    void Update()
    {
        if (!isRising) return;

        currentSpeed = Mathf.Min(currentSpeed + speedIncreaseRate * Time.deltaTime, maxRiseSpeed);

        transform.position += Vector3.right * currentSpeed * Time.deltaTime;

        if (transform.position.x >= maxX)
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
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