using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Managers;

namespace UdemyProject2.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        public void SelectAndStartButton(int index)
        {
            GameManager.Instance.DifficultyIndex = index;
            GameManager.Instance.LoadScene("Game");
        }
        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
    }
}

