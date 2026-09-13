using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void LateUpdate()
    {
        float clampX = Mathf.Clamp(player.position.x, minX, maxX);
        float clampY = Mathf.Clamp(player.position.y, minY, maxY);

        transform.position = new Vector3(clampX, clampY, -10f);
    }
}
