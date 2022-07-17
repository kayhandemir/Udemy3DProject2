using UnityEngine;
using UdemyProject2.Managers;

namespace UdemyProject2.Uis
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] OverPanel _gameOverPanel;
        private void Awake()
        {
            _gameOverPanel.gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            GameManager.Instance.OnGameStop += HandleOnGameStop;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnGameStop -= HandleOnGameStop;
        }
        void HandleOnGameStop()
        {
            _gameOverPanel.gameObject.SetActive(true);
        }
    }
}

