using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    public GameObject correctImage;
    public GameObject incorrectImage;
    public float displayTime = 1f;

    public void ShowFeedback(bool isCorrect)
    {
        StopAllCoroutines();
        StartCoroutine(Show(isCorrect));
    }

    private System.Collections.IEnumerator Show(bool isCorrect)
    {
        if (isCorrect) correctImage.SetActive(true);
        else incorrectImage.SetActive(true);

        yield return new WaitForSeconds(displayTime);

        correctImage.SetActive(false);
        incorrectImage.SetActive(false);
    }
}
