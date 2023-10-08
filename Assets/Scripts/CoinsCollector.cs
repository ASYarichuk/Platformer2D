using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
        }
    }
}
