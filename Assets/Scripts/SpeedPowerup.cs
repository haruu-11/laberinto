using UnityEngine;
using System.Collections;

public class SpeedPowerup : MonoBehaviour
{
    public float speedBoost = 2f;
    public float duration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player =
                other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                StartCoroutine(
                    BoostSpeed(player)
                );
            }

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator BoostSpeed(PlayerMovement player)
    {
        player.speed += speedBoost;

        yield return new WaitForSeconds(duration);

        player.speed -= speedBoost;

        Destroy(gameObject);
    }
}