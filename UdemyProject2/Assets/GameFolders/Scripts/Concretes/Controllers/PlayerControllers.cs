using UnityEngine;
using UdemyProject2.Movements;
using UdemyProject2.Abstracts.Inputs;
using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Inputs;
using UnityEngine.InputSystem;
using UdemyProject2.Managers;
using UdemyProject2.Abstracts.Movements;

namespace UdemyProject2.Controllers
{
    public class PlayerControllers : MyCharecterController,IentitiyController
    {
        [SerializeField] float _jumpForce = 300f;

        IMover _mover;
        IJump _jumpWithRigidbody;
        IInputReader _inputReader;
        float _horizontal;
        bool _isDead = false;
        private void Awake()
        {
            _mover = new HorizontalMovements(this);
            _jumpWithRigidbody = new JumpWithRigidbody(this);
            _inputReader = new InputReader(GetComponent<PlayerInput>());
        }
        private void Update()
        {
            if (_isDead) return;

            _horizontal = _inputReader.Horizontal;
        }
        private void FixedUpdate()
        {
            _mover.FixedTick(_horizontal);
            if (_inputReader.IsJump)
            {
                _jumpWithRigidbody.FixedTick(_jumpForce);
            }
            _inputReader.IsJump = false;
        }
        private void OnTriggerEnter(Collider collision)
        {
            IentitiyController _entityController = collision.GetComponent<IentitiyController>();
            if (_entityController!=null)
            {
                _isDead = true;
                GameManager.Instance.StopGame();
            }
        }
    }
}

