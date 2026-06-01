using UnityEngine;

public class WaterSpeedReset : MonoBehaviour
{
    [SerializeField] private RisingWater risingWater;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            risingWater.ResetSpeed();
            Destroy(gameObject);
        }

    }
}
