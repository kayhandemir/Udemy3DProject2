using UnityEngine;
using UdemyProject2.Controllers;
using UdemyProject2.Abstracts.Movements;
using UdemyProject2.Abstracts.Controllers;

namespace UdemyProject2.Movements
{
    public class VerticalMovements :IMover
    {
        IentitiyController _entityController;
        public VerticalMovements(IentitiyController entitiyController)
        {
            _entityController = entitiyController;
        }
        public void FixedTick(float direction)
        {
            _entityController.transform.Translate(Vector3.back * direction * _entityController.MoveSpeed * Time.deltaTime);
        }

    }
}

