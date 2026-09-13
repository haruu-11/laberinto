using UnityEngine;
using UnityEngine.UI;

public class ArrowPointer : MonoBehaviour
{
    public Transform player;
    public Transform target;

    private RectTransform rect;
    private Image image;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        image.enabled = false;
    }

    void LateUpdate()
    {
        if (
            !image.enabled ||
            target == null
        )
        {
            return;
        }

        Vector3 direction =
            target.position -
            player.position;

        direction.Normalize();

        float angle =
            Mathf.Atan2(
                direction.y,
                direction.x
            ) * Mathf.Rad2Deg;

        rect.localRotation =
            Quaternion.Euler(
                0,
                0,
                angle - 90f
            );

        Vector3 playerScreenPos =
            Camera.main.WorldToScreenPoint(
                player.position
            );

        float distanceFromPlayer = 60f;

        rect.position =
            playerScreenPos +
            direction * distanceFromPlayer;
    }

    public void ShowArrow()
    {
        image.enabled = true;
    }

    public void HideArrow()
    {
        image.enabled = false;
    }
}