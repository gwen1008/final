using UnityEngine;
using TMPro;
using System.Collections;

namespace GWEN
{
    public class HuggingFaceManager : MonoBehaviour
    {
        [SerializeField, Header("�@���B�J")]
        private StoryStep[] storySteps; // �@���޿�
        [SerializeField, Header("�n���ʪ� NPC")]
        private NPCController npc; // ���N NPC
        [SerializeField, Header("���a��J��")]
        private TMP_InputField inputFieldPlayer; // ���a��J��
        [SerializeField, Header("���ܮ�")]
        private TMP_Text promptText; // ��ܴ��ܪ��奻��

        private int currentStep = 0; // ��e�G�ƶi��

        private void Awake()
        {
            ShowPrompt();
            inputFieldPlayer.onEndEdit.AddListener(CheckAnswer); // ��ť���a��J
        }

        private void ShowPrompt()
        {
            if (currentStep < storySteps.Length)
            {
                promptText.text = storySteps[currentStep].prompt; // ��ܷ�e����
                inputFieldPlayer.text = ""; // �M�ſ�J��
                inputFieldPlayer.ActivateInputField(); // �E����J��
            }
            else
            {
                promptText.text = "���ߧA�����F�Ҧ��D�ԡI"; // �̲״���
                npc.PlayAinmation(4); // ���񧹦��ʵe�A�Ҧp�u�����v
            }
        }

        private void CheckAnswer(string input)
        {
            if (currentStep >= storySteps.Length) return; // �w�����C���h���L

            if (input.ToLower().Trim() == storySteps[currentStep].correctAnswer.ToLower())
            {
                npc.PlayAinmation(storySteps[currentStep].animationIndex); // ���񥿽T�ʵe
                currentStep++; // ���i�G�ƶi��
                ShowPrompt(); // ��ܤU�@�B����
            }
            else
            {
                promptText.text = storySteps[currentStep].hint; // ��ܿ��~����
                npc.PlayAinmation(1); // ������~�ʵe�A�Ҧp�u�n�Y�v
            }
        }
    }
}
