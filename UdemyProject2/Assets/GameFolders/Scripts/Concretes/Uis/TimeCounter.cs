using UnityEngine;
using TMPro;

namespace UdemyProject2.Uis 
{
    public class TimeCounter : MonoBehaviour
    {
        TMP_Text _text;
        float _curretTime;
        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }
        private void Update()
        {
            _curretTime += Time.deltaTime;
            _text.text = _curretTime.ToString(format:"0");
        }
    }
}

