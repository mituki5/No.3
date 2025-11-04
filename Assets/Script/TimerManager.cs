using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Slider timerSlider;
    public float timeLimit = 120f;
    private float timeRemaining;
    private bool isTiming = false;

    private QuizManager quizManager;

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        timerSlider.maxValue = timeLimit;
        timerSlider.value = timeLimit;
    }

    public void StartTimer()
    {
        timeRemaining = timeLimit;
        timerSlider.value = timeRemaining;
        isTiming = true;
    }

    void Update()
    {
        if (!isTiming) return;

        timeRemaining -= Time.deltaTime;
        timerSlider.value = timeRemaining;

        if (timeRemaining <= 0f)
        {
            isTiming = false;
            quizManager.TimeUp();
        }
    }

    public void StopTimer()
    {
        isTiming = false;
    }
}
