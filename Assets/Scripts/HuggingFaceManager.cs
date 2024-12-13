using UnityEngine;
using TMPro;
using System.Collections;

namespace GWEN
{
    public class HuggingFaceManager : MonoBehaviour
    {
        [SerializeField, Header("劇情步驟")]
        private StoryStep[] storySteps; // 劇情邏輯
        [SerializeField, Header("要互動的 NPC")]
        private NPCController npc; // 老鷹 NPC
        [SerializeField, Header("玩家輸入框")]
        private TMP_InputField inputFieldPlayer; // 玩家輸入框
        [SerializeField, Header("提示框")]
        private TMP_Text promptText; // 顯示提示的文本框

        private int currentStep = 0; // 當前故事進度

        private void Awake()
        {
            ShowPrompt();
            inputFieldPlayer.onEndEdit.AddListener(CheckAnswer); // 監聽玩家輸入
        }

        private void ShowPrompt()
        {
            if (currentStep < storySteps.Length)
            {
                promptText.text = storySteps[currentStep].prompt; // 顯示當前提示
                inputFieldPlayer.text = ""; // 清空輸入框
                inputFieldPlayer.ActivateInputField(); // 激活輸入框
            }
            else
            {
                promptText.text = "恭喜你完成了所有挑戰！"; // 最終提示
                npc.PlayAinmation(4); // 播放完成動畫，例如「飛翔」
            }
        }

        private void CheckAnswer(string input)
        {
            if (currentStep >= storySteps.Length) return; // 已完成遊戲則跳過

            if (input.ToLower().Trim() == storySteps[currentStep].correctAnswer.ToLower())
            {
                npc.PlayAinmation(storySteps[currentStep].animationIndex); // 播放正確動畫
                currentStep++; // 推進故事進度
                ShowPrompt(); // 顯示下一步提示
            }
            else
            {
                promptText.text = storySteps[currentStep].hint; // 顯示錯誤提示
                npc.PlayAinmation(1); // 播放錯誤動畫，例如「搖頭」
            }
        }
    }
}
