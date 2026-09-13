using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TMP_Text timerText;

    private bool gameRunning = true;
    private bool showedArrow = false;

    void Update()
    {
        if (gameRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;

                GameUI.instance.ShowLose();
            }

            UpdateTimerUI();
        }

        if (
            timeRemaining <= 30 &&
            !showedArrow &&
            !GameManager.hasKey
        )
        {
            GameObject.Find("KeyArrow")
                .GetComponent<ArrowPointer>()
                .ShowArrow();

            showedArrow = true;
        }
    }

    void UpdateTimerUI()
    {
        timerText.text =
            "Tiempo: " +
            Mathf.Ceil(timeRemaining);
    }
}