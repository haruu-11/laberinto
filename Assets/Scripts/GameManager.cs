using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool hasKey = false;

    private void Awake()
    {
        hasKey = false;
    }
}