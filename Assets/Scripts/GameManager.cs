using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject GameStartScreen, GameMenuScreen, GameOverScreen;
    // Start is called before the first frame update

    private void Start()
    {
        Time.timeScale = 0f;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("Game Over");
        GameOverScreen.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        GameStartScreen.SetActive(false);
        GameMenuScreen.SetActive(true);
    }

    public void ReloadScene()
    {
        GameMenuScreen.SetActive(false);
        GameOverScreen.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
