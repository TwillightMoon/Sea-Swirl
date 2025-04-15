using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputReader : Singleton<PlayerInputReader>
{
    [Header("Components")]
    [SerializeField]
    private PlayerInput _playerInput;

    private void OnValidate()
    {
        _playerInput ??= GetComponent<PlayerInput>();
    }

    public InputAction GetAction(PlayerInputKeys key)
    {
        return _playerInput.actions[Enum.GetName(typeof(PlayerInputKeys), key)];
    }
}

public enum PlayerInputKeys
{
    Movement,
    Mouse
}