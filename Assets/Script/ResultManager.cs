using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public Text scoreText;
    public Text correctText;
    public Button retryButton;

    void Start()
    {
        retryButton.onClick.AddListener(ReturnToTitle);
    }

    public void ShowResult(int score, int correctCount)
    {
        scoreText.text = "ÉXÉRÉA: " + score;
        correctText.text = "ê≥ìöêî: " + correctCount;
        gameObject.SetActive(true);
    }

    void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
