using UnityEngine;
using UdemyProject2.Controllers;
using UdemyProject2.Abstracts.Movements;

namespace UdemyProject2.Movements
{
    public class JumpWithRigidbody:IJump
    {
        Rigidbody _rigidbody;
        public bool CanJump => _rigidbody.velocity.y != 0f;
        public JumpWithRigidbody(PlayerControllers player)
        {
            _rigidbody = player.GetComponent<Rigidbody>();
        }
        public void FixedTick(float jumpForce)
        {
            if (CanJump) return;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * Time.deltaTime * jumpForce);
        }
    }
}

