using UnityEngine.InputSystem;
using UdemyProject2.Abstracts.Inputs;

namespace UdemyProject2.Inputs
{
    public class InputReader : IInputReader
    {
        PlayerInput _playerInput;
        public float Horizontal { get; private set; }

        public bool IsJump { get; set; }

        public InputReader(PlayerInput playerInput)
        {
            _playerInput = playerInput;
            _playerInput.currentActionMap.actions[0].performed+=OnHorizontalMove;
            _playerInput.currentActionMap.actions[1].performed += OnJump;
        }
        void OnHorizontalMove(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<float>();
        }
        void OnJump(InputAction.CallbackContext context)
        {
            IsJump = context.ReadValueAsButton();
        }
    }
}

