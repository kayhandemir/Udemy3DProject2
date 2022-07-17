using UnityEngine;

namespace UdemyProject2.Abstracts.Controllers
{
    public abstract class MyCharecterController:MonoBehaviour
    {
        [SerializeField] float _moveBoundary = 4.5f;
        [SerializeField] protected float _moveSpeed = 10F;
        public float MoveBoundary => _moveBoundary;
        public float MoveSpeed => _moveSpeed;
    }
}

