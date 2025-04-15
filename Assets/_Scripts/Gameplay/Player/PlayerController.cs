using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerModel))]
[RequireComponent(typeof(PlayerInputReader))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerModel _playerModel;
    
    [SerializeField]
    private CharacterController _characterController;
    
    [SerializeField]
    private GroundChecker _groundChecker;
    
    private PlayerMovement _playerMovement;
    private PlayerRotation _playerRotation;
    
    

    private void OnValidate()
    {
        _characterController ??= GetComponent<CharacterController>();
        _playerModel ??= GetComponent<PlayerModel>();
    }

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        _playerMovement = new PlayerMovement(_characterController, _playerModel, _groundChecker);
        _playerRotation = new PlayerRotation(_playerModel, Camera.main.transform);
        
        _playerRotation.SubscribeToReader();
    }

    private void Update()
    {
        _playerMovement.Move();
        _playerRotation.Rotate();
    }
}
