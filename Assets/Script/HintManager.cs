using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    public int maxHints = 5;
    private int remainingHints;

    [Header("UI Elements")]
    public GameObject hintDisplay;
    public Text hintText;
    public Image hintBackgroundImage;

    void Start()
    {
        remainingHints = maxHints;
        hintDisplay.SetActive(false);
    }

    public void ShowHint(string text, QuizManager quizManager)
    {
        if (remainingHints <= 0) return;

        hintText.text = text;
        hintDisplay.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(HideHintAfterSeconds(3f));

        // QuizManager 側に問い合わせてヒント使用状況を確認
        if (!quizManager.IsSameQuestionHintUsed())
        {
            remainingHints--;
            quizManager.MarkHintUsedForCurrentQuestion();
        }
    }

    private IEnumerator HideHintAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        hintDisplay.SetActive(false);
    }

    public int GetRemainingHints() => remainingHints;
}
