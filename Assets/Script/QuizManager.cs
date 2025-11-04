using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [Header("Backgrounds")]
    public Image backgroundImage; // QuizPanelîwåi
    public Sprite stage1Background;
    public Sprite stage2Background;
    public Sprite stage3Background;

    [Header("Question Data")]
    public List<QuestionData> allQuestions;
    private List<QuestionData> currentStageQuestions;
    private int currentQuestionIndex = 0;

    [Header("Managers")]
    public UIManager uiManager;
    public TimerManager timerManager;
    public FeedbackManager feedbackManager;
    public HintManager hintManager;

    private int score = 0;
    private int correctCount = 0;

    // åªç›ÇÃñ‚ëËÇ≈ÉqÉìÉgÇégÇ¡ÇΩÇ©Ç«Ç§Ç©ä«óù
    private HashSet<int> hintUsedQuestions = new HashSet<int>();

    public void StartStage(string category)
    {
        // ÉXÉeÅ[ÉWîwåiêÿë÷
        switch (category)
        {
            case "ìVäØéíïü": backgroundImage.sprite = stage1Background; break;
            case "ñÇìπëcét": backgroundImage.sprite = stage2Background; break;
            case "êlü‘îΩîhé©ã~ånìù": backgroundImage.sprite = stage3Background; break;
            default: backgroundImage.sprite = null; break;
        }

        // ñ‚ëËÉäÉXÉgçÏê¨
        currentStageQuestions = allQuestions.FindAll(q => q.category == category);
        Shuffle(currentStageQuestions);
        currentQuestionIndex = 0;
        hintUsedQuestions.Clear();

        ShowNextQuestion();
    }

    public void ShowNextQuestion()
    {
        if (currentQuestionIndex >= currentStageQuestions.Count)
        {
            uiManager.ShowResult(score, correctCount);
            return;
        }

        QuestionData q = currentStageQuestions[currentQuestionIndex];
        uiManager.DisplayQuestion(q);
        timerManager.StartTimer();
    }

    public void SubmitAnswer(string userAnswer)
    {
        QuestionData q = currentStageQuestions[currentQuestionIndex];
        bool isCorrect = userAnswer.Trim().ToLower().Contains(q.answer.Trim().ToLower());
        if (isCorrect)
        {
            score += 10;
            correctCount++;
        }

        feedbackManager.ShowFeedback(isCorrect);
        currentQuestionIndex++;
        ShowNextQuestion();
    }

    public void TimeUp()
    {
        feedbackManager.ShowFeedback(false);
        currentQuestionIndex++;
        ShowNextQuestion();
    }

    public QuestionData GetCurrentQuestion()
    {
        if (currentQuestionIndex < currentStageQuestions.Count)
            return currentStageQuestions[currentQuestionIndex];
        return null;
    }

    // ÉqÉìÉgä«óùópä÷êî
    public bool IsSameQuestionHintUsed()
    {
        return hintUsedQuestions.Contains(currentQuestionIndex);
    }

    public void MarkHintUsedForCurrentQuestion()
    {
        hintUsedQuestions.Add(currentQuestionIndex);
    }

    private void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
