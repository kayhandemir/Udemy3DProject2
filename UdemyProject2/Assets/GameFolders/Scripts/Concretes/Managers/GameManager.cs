using System.Collections;
using UnityEngine;
using UdemyProject2.Abstracts.Utilities;
using UnityEngine.SceneManagement;
using UdemyProject2.ScriptableObjects;

namespace UdemyProject2.Managers
{
    public class GameManager : SingletonMonoBehaviorObject<GameManager>
    {
        [SerializeField] LevelDifficultyData[] _levelDifficultyDatas;

        public LevelDifficultyData LevelDifficultyData => _levelDifficultyDatas[DifficultyIndex];
        int _difficulyIndex;
        public int DifficultyIndex 
        { 
            get => _difficulyIndex;
            set
            {
                if (_difficulyIndex<0||_difficulyIndex > _levelDifficultyDatas.Length)
                {
                    LoadSceneAsync("Menu");
                }
                else
                {
                    _difficulyIndex = value;
                }
            } 
        }

        public event System.Action OnGameStop;
        private void Awake()
        {
            SingletonThisObject(this);
        }
        public void StopGame()
        {
            Time.timeScale = 0f;
            OnGameStop?.Invoke();
        }
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }
        private IEnumerator LoadSceneAsync(string sceneName)
        {    
            yield return SceneManager.LoadSceneAsync(sceneName);
            Time.timeScale = 1f;
        }
        public void ExitGame()
        {
            Debug.Log("Oyundan çýktýn!");
            Application.Quit();
        }
    }
}

