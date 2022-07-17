using UnityEngine;
using UdemyProject2.Managers;
using UdemyProject2.Enums;

namespace UdemyProject2.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [Range(0.1f,5.0f)]
        [SerializeField] float _min = 0.1f;
        [Range(6.0f,15.0f)]
        [SerializeField] float _max = 15f;

        public bool CanIncrease => _index < EnemyManager.Instance.Count;

        float _maxSpawnTime;
        float _currentSpawnTime = 0f;
        float _maxAddEnemyTime;

        int _index = 0;
        private void OnEnable()
        {
            GetRandomTime();
        }
        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;

            if (_currentSpawnTime>_maxSpawnTime)
            {
                Spawn();
            }

            if (!CanIncrease) return;

            if (_maxAddEnemyTime<Time.time)
            {
                _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
                IncreaseIndex();
            }
        }

        private void IncreaseIndex()
        {
            if (CanIncrease)
            {
                _index++;
            }
        }
        void Spawn()
        {
            EnemyController newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)Random.Range(0,_index));
            newEnemy.transform.parent = this.transform;
            newEnemy.transform.position = this.transform.position;
            newEnemy.gameObject.SetActive(true);

            _currentSpawnTime = 0f;
            GetRandomTime();
        }
        private void GetRandomTime()
        {
            _maxSpawnTime = Random.Range(_min, _max);
        }
    }
}

