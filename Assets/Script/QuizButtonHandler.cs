using UnityEngine;
using UnityEngine.UI;

public class QuizButtonHandler : MonoBehaviour
{
    public QuizManager quizManager;
    public HintManager hintManager;
    public InputField inputField;

    void Update()
    {
        if (inputField.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            OnInputSubmit();
        }
    }

    // 4‘ğƒ{ƒ^ƒ“
    public void OnChoiceSelected(string choice)
    {
        quizManager.SubmitAnswer(choice);
        inputField.text = "";
    }

    // Z~ƒ{ƒ^ƒ“
    public void OnTrueFalseSelected(bool isTrue)
    {
        string answer = isTrue ? "Z" : "~";
        quizManager.SubmitAnswer(answer);
        inputField.text = "";
    }

    // “ü—Í®‘—M
    public void OnInputSubmit()
    {
        string userInput = inputField.text;
        if (!string.IsNullOrEmpty(userInput))
        {
            quizManager.SubmitAnswer(userInput);
            inputField.text = "";
        }
    }

    // ƒqƒ“ƒgƒ{ƒ^ƒ“
    public void OnHintButton()
    {
        QuestionData currentQ = quizManager.GetCurrentQuestion();
        if (currentQ != null)
        {
            hintManager.ShowHint(currentQ.hintText, quizManager);
        }
    }
}
