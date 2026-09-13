using UnityEngine;

public class Door : MonoBehaviour
{
    private Collider2D doorCollider;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        doorCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GameManager.hasKey)
        {
            doorCollider.isTrigger = true;

            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(
        Collider2D other
    )
    {
        if (
            other.CompareTag("Player")
            &&
            GameManager.hasKey
        )
        {
            GameUI.instance.ShowWin();
        }
     
    }
    
}