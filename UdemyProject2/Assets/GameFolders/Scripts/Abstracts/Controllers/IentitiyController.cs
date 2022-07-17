using UnityEngine;

namespace UdemyProject2.Abstracts.Controllers
{
    public interface IentitiyController
    {
        Transform transform { get; }
        float MoveSpeed { get; }
        float MoveBoundary { get; }
    }
}

