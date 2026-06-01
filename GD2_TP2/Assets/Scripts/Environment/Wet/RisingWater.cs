using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingWater : MonoBehaviour
{
    [Header("Rising")]
    [SerializeField] private float riseSpeed = 1f;
    [SerializeField] private float maxX = 20f;

    [Header("Scene")]
    [SerializeField] private string levelSceneName;

    private bool isRising = false;

    public void StartRising()
    {
        isRising = true;
    }

    void Update()
    {
        if (!isRising) return;

        transform.position += Vector3.right * riseSpeed * Time.deltaTime;

        if (transform.position.x >= maxX)
            transform.position = new Vector3(
                maxX, transform.position.y, transform.position.z);
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