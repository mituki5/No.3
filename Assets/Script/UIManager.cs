using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject titlePanel;
    public GameObject formatSelectPanel;
    public GameObject stageSelectPanel;
    public GameObject quizPanel;
    public GameObject resultPanel;

    public Text questionText;
    public GameObject choicesPanelFour;
    public GameObject choicesPanelTrueFalse;
    public InputField inputField;

    public ResultManager resultManager;

    public void DisplayQuestion(QuestionData q)
    {
        quizPanel.SetActive(true);
        titlePanel.SetActive(false);
        formatSelectPanel.SetActive(false);
        stageSelectPanel.SetActive(false);

        questionText.text = q.questionText;

        // èoëËå`éÆÇ…âûÇ∂ÇƒUIêÿë÷
        choicesPanelFour.SetActive(q.format == "4ë");
        choicesPanelTrueFalse.SetActive(q.format == "ÅZÅ~");
        inputField.gameObject.SetActive(q.format == "ì¸óÕ");
    }

    public void ShowResult(int score, int correctCount)
    {
        quizPanel.SetActive(false);
        resultPanel.SetActive(true);
        resultManager.ShowResult(score, correctCount);
    }
}
