using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject gameOverUI;


    private void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }   

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }
}
