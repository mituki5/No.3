using System;

[Serializable]
public class QuestionData
{
    public string questionText;    // 中国語問題文
    public string hintText;        // 日本語ヒント
    public string choiceA;
    public string choiceB;
    public string choiceC;
    public string choiceD;
    public string answer;          // 正解
    public string format;          // "4択", "〇×", "入力"
    public string category;        // ステージ
}
