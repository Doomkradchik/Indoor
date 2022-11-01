using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRouter : MonoBehaviour
{
    [SerializeField]
    private PlayerRoot _player;

    [SerializeField]
    private CamerasManager _camerasManager;

    [SerializeField]
    private Instuction _instruction;

    [SerializeField]
    private Animator _nextBut;
    [SerializeField]
    private Animator _prevBut;
    [SerializeField]
    private Animator _powerBut;

    public event Action GameLaunched;

    private GameInputs _input;
    private readonly string _pressedKey = "Pressed";

    private bool _buttonSPACEEnabled = true;

    private void OnEnable()
    {
        _input = new GameInputs();
        _input.TV.NextCamera.performed += OnNextCameraShifted;
        _input.TV.PrevCamera.performed += OnPrevCameraShifted;
        _input.TV.PowerOn.performed += OnTVLaunched;

        _input.Player.Interaction.started += OnEButtonDown;
        _input.Player.Interaction.canceled += OnEButtonUp;

        _input.Enable();
    }

    private void OnDisable()
    {
        _input.TV.NextCamera.performed -= OnNextCameraShifted;
        _input.TV.PrevCamera.performed -= OnPrevCameraShifted;
        _input.TV.PowerOn.performed -= OnTVLaunched;

        _input.Player.Interaction.started -= OnEButtonDown;
        _input.Player.Interaction.canceled -= OnEButtonUp;

        _input.Disable();
    }

    private void FixedUpdate()
    {
        var input = _input.Player.Movement.ReadValue<Vector2>();
        _player.Movement.Move(input);
    }

    private void OnTVLaunched(InputAction.CallbackContext obj)
    {
        _instruction.Next();

    }

    private void OnPrevCameraShifted(InputAction.CallbackContext obj)
    {
        _prevBut.SetTrigger(_pressedKey);
        _camerasManager.Previous();
    }

    private void OnNextCameraShifted(InputAction.CallbackContext obj)
    {
        _nextBut.SetTrigger(_pressedKey);
        _camerasManager.Next();
    }

    private void OnEButtonDown(InputAction.CallbackContext context)
    {
         _player.TryDoInteraction();
    }

    private void OnEButtonUp(InputAction.CallbackContext context)
    {
        _player.TryCancelIntercation();
    }

}
