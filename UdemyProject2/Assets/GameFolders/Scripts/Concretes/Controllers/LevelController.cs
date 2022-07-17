using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.ScriptableObjects;
using UdemyProject2.Managers;

namespace UdemyProject2.Controllers
{
    public class LevelController : MonoBehaviour
    {
        LevelDifficultyData _levelDifficultyData;
        private void Awake()
        {
            _levelDifficultyData = GameManager.Instance.LevelDifficultyData;
        }
        void Start()
        {
            RenderSettings.skybox = _levelDifficultyData.SkyBoxMetarial;
            Instantiate(_levelDifficultyData.FloorPrefabs);
            Instantiate(_levelDifficultyData.SpanwerPrefab);
            EnemyManager.Instance.SetMoveSpeed(_levelDifficultyData.MoveSpeed);
            EnemyManager.Instance.SetAddDelayTime(_levelDifficultyData.AddDelayTime);
        }
    }
}

