using UnityEngine;
namespace UdemyProject2.Controllers
{
    public class FloorController : MonoBehaviour
    {
        [Range(1f,5f)]
        [SerializeField] float _moveSpeed;
        Material _material;
        private void Awake()
        {
            _material = GetComponentInChildren<MeshRenderer>().material;
        }
        private void Update()
        {
            _material.mainTextureOffset+=Vector2.down * Time.deltaTime * _moveSpeed;
        }
    }
}

