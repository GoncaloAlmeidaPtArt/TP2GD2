using UnityEngine;

public class addTimeToTimer : MonoBehaviour
{

    [SerializeField] private tempofinal tempinho;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            
            tempinho.addTime();
            Destroy(gameObject);
        }

    }
}
