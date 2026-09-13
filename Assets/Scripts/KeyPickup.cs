using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.hasKey = true;
           

            Debug.Log("Tengo llave");

            GameObject.Find("KeyArrow")
    .GetComponent<ArrowPointer>()
    .HideArrow();

            GameObject.Find("DoorArrow")
                .GetComponent<ArrowPointer>()
                .ShowArrow();

            GameUI.instance.UpdateKeyUI(true);

            Destroy(gameObject);
        }
     
    }
}