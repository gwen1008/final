using UnityEngine;

[System.Serializable]
public class StoryStep
{
    public string prompt;        // 提示文字
    public string correctAnswer; // 正確答案
    public string hint;          // 錯誤時的提示
    public int animationIndex;   // 正確答案時播放的動畫索引
}
