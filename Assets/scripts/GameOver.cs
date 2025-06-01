using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    void OnEnable()
    {
        roundsText.text = "Waves survived: " + (PlayerStats.Rounds - 2).ToString();
    }

    public void Retry()
    {
        GameManager.GameIsOver = false;
        PlayerStats.Rounds = 1;
        PlayerStats.Lives = PlayerStats.startLives;
        PlayerStats.Money = PlayerStats.StartMoney;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        GameManager.GameIsOver = false;
        PlayerStats.Rounds = 1;
        PlayerStats.Lives = PlayerStats.startLives;
        PlayerStats.Money = PlayerStats.StartMoney;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}