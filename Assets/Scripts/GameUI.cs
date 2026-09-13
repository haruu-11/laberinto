using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject winPanel;

    public TMP_Text keyText;

    public static GameUI instance;

    void Awake()
    {
        instance = this;

        losePanel.SetActive(false);
        winPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void ShowLose()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowWin()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UpdateKeyUI(bool hasKey)
    {
        if (hasKey)
        {
            keyText.text = "Llave: Sí";
        }
        else
        {
            keyText.text = "Llave: No";
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameManager.hasKey = false;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameManager.hasKey = false;

        SceneManager.LoadScene("MainMenu");
    }
}