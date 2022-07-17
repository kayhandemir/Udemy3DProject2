using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Managers;

namespace UdemyProject2.Uis
{
    public class OverPanel : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.Instance.LoadScene("Game");
        }
        public void NoButton()
        {
            GameManager.Instance.LoadScene("Menu");
        }
    }
}

