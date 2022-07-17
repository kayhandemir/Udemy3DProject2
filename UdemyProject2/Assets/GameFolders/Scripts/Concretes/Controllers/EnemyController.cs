using UnityEngine;
using UdemyProject2.Movements;
using UdemyProject2.Managers;
using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Enums;

namespace UdemyProject2.Controllers
{
    public class EnemyController : MyCharecterController,IentitiyController
    {
        [SerializeField] float _maxLifetime = 5f;
        [SerializeField] float _direction = 1f;
        [SerializeField] EnemyEnum _enemyEnum;

        VerticalMovements _verticalMovements;
        public float Direction => _direction;

        float _currentLifeTime = 0f;
        public EnemyEnum EnemyType => _enemyEnum;
        private void Awake()
        {
            _verticalMovements = new VerticalMovements(this);   
        }
        private void Update()
        {
            _currentLifeTime += Time.deltaTime;
            if (_currentLifeTime>_maxLifetime)
            {
                _currentLifeTime = 0f;
                KillYourSelf();
            }
        }
        private void FixedUpdate()
        {
            _verticalMovements.FixedTick(Direction);
        }
        void KillYourSelf()
        {
            EnemyManager.Instance.SetPool(this);
        }
        public void SetMoveSpeed(float moveSpeed)
        {
            if (moveSpeed < _moveSpeed) return;
            _moveSpeed = moveSpeed;
        }
    }
}
