using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    public TextAsset csvFile;

    public List<QuestionData> LoadQuestions()
    {
        List<QuestionData> questions = new List<QuestionData>();
        string[] lines = csvFile.text.Split(new char[] { '\n' });

        for (int i = 1; i < lines.Length; i++) // 1行目はヘッダー
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            string[] values = lines[i].Split(',');

            QuestionData q = new QuestionData
            {
                questionText = values[1],
                hintText = values[2],
                choiceA = values[3],
                choiceB = values[4],
                choiceC = values[5],
                choiceD = values[6],
                answer = values[7],
                format = values[8],
                category = values[9]
            };
            questions.Add(q);
        }
        return questions;
    }
}
