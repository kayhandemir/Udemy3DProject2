using UnityEngine;
using UdemyProject2.Abstracts.Controllers;
using UdemyProject2.Abstracts.Movements;

namespace UdemyProject2.Movements
{
    public class HorizontalMovements:IMover
    {
        IentitiyController _playerController;
        public HorizontalMovements(IentitiyController entitiyController)
        {
            _playerController = entitiyController;
        }
        public void FixedTick(float horizontal)
        {
            if (horizontal == 0) return;
            _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _playerController.MoveSpeed);
            float xboundary = Mathf.Clamp(_playerController.transform.position.x, -_playerController.MoveBoundary, _playerController.MoveBoundary);
            _playerController.transform.position = new Vector3(xboundary, _playerController.transform.position.y, 0);
        }
    }
}

