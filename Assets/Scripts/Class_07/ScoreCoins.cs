using UnityEngine;

public class ScoreCoins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            other.gameObject.SetActive(false);
        }
    }
}
