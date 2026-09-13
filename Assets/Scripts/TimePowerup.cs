using UnityEngine;

public class TimePowerup : MonoBehaviour
{
    public float extraTime = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameTimer timer = FindObjectOfType<GameTimer>();

            if (timer != null)
            {
                timer.timeRemaining += extraTime;
            }

            Destroy(gameObject);
        }
    }
}