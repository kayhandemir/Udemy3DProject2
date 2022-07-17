using System.Collections.Generic;
using UnityEngine;
using UdemyProject2.Abstracts.Utilities;
using UdemyProject2.Controllers;
using UdemyProject2.Enums;

namespace UdemyProject2.Managers
{
    public class EnemyManager : SingletonMonoBehaviorObject<EnemyManager>
    {
        [SerializeField] EnemyController[] _enemyPrefabs;
        [SerializeField] float _addDelayTime = 50f;

        Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum, Queue<EnemyController>>();

        float _moveSpeed;
        public float AddDelayTime => _addDelayTime;

        public int Count => _enemyPrefabs.Length;

        private void Awake()
        {
            SingletonThisObject(this);
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }
        public void SetAddDelayTime(float addDelayTime)
        {
            _addDelayTime = addDelayTime;
        }

        private void Start()
        {
            InitializePool();
        }
        public void InitializePool()
        {
            for (int i = 0; i < _enemyPrefabs.Length; i++)
            {
                Queue<EnemyController> enemyControllers = new Queue<EnemyController>();
                for (int j = 0; j < 10; j++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[i]);
                    newEnemy.gameObject.SetActive(false);
                    newEnemy.transform.parent = this.transform;
                    enemyControllers.Enqueue(newEnemy);
                }
                _enemies.Add((EnemyEnum)i, enemyControllers);
            }          
        }
        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;
            Queue<EnemyController> enemyControllers = _enemies[enemyController.EnemyType];
            enemyControllers.Enqueue(enemyController);
        }
        public EnemyController GetPool(EnemyEnum enemyType)
        {
            Queue<EnemyController> enemyControllers = _enemies[enemyType];
            if (enemyControllers.Count==0)
            {
                for (int i = 0; i < 2; i++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[(int)enemyType]);
                    newEnemy.gameObject.SetActive(false);
                    enemyControllers.Enqueue(newEnemy);
                }          
            }
            EnemyController enemyController = enemyControllers.Dequeue();
            enemyController.SetMoveSpeed(_moveSpeed);
            return enemyController;
        }
    }
}

