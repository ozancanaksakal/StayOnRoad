using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject loseUI, winUI;

    public int score;

    public Text loseScoreText, winScoreText, inGameScoreText;

    private void Start() {
        loseUI.SetActive(false);
        winUI.SetActive(false);
    }

    public void LoseLevel()
    {
        loseUI.SetActive(true);
        loseScoreText.text = "Toplam Puan: " + score;
        inGameScoreText.gameObject.SetActive(false);
    }
    public void WinLevel()
    {
        winScoreText.text = "Toplam Puan: " + score;
        winUI.SetActive(true);
        inGameScoreText.gameObject.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Level01");
    }

    public void AddScore(int value)
    {
        score += value;
        inGameScoreText.text = "Puan: " + score;
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}