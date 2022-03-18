using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace HeroicArcade
{

    [Serializable]
    public class MoveInputEvent : UnityEvent<Vector2>
    {
    }

    [Serializable]
    public class LookInputEvent : UnityEvent<Vector2>
    {
    }

    public class InputController : MonoBehaviour
    {
        [SerializeField] MoveInputEvent moveInputEvent;
        [SerializeField] MoveInputEvent lookInputEvent;

        [HideInInspector] public float Vertical;
        [HideInInspector] public float Horizontal;
        [HideInInspector] public Vector2 MouseInput;

        Controls controls;

        private void Awake()
        {
            Controls controls = new Controls();

            controls.Gameplay.Move.started += OnMoveInput;
            controls.Gameplay.Move.canceled += OnMoveInput;

            controls.Gameplay.Look.started += OnLookInput;
            controls.Gameplay.Look.canceled += OnLookInput;
        }

        private Vector2 moveInput;
        [HideInInspector] public bool IsMovePressed;
        private void OnMoveInput(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
            IsMovePressed = (moveInput != Vector2.zero);
            moveInputEvent.Invoke(moveInput);
        }

        private Vector2 lookInput;
        [HideInInspector] public bool IsLookPressed;
        private void OnLookInput(InputAction.CallbackContext context)
        {
            lookInput = context.ReadValue<Vector2>();
            IsLookPressed = (lookInput != Vector2.zero);
            lookInputEvent.Invoke(lookInput);
        }

        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Disable();
        }
    }

} //ns HeroicArcade