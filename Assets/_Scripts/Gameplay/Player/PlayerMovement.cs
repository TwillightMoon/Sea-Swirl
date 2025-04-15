using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement
{
    private const float GRAVITY = 9.8f;
    
    private CharacterController _controller;
    private PlayerModel _playerModel;
    private GroundChecker _groundChecker;

    private Vector2 _currentDirection;

    private float _currentYSpeed = 0;

    public PlayerMovement(CharacterController controller, PlayerModel playerModel, GroundChecker groundChecker)
    {
        _controller = controller;
        _playerModel = playerModel;
        _groundChecker = groundChecker;

        PlayerInputReader.instance.GetAction(PlayerInputKeys.Movement).performed += OnNewDirection;
        PlayerInputReader.instance.GetAction(PlayerInputKeys.Movement).canceled += OnNewDirection;
    }

    public void Move()
    {
        Vector3 velocity = new Vector3(_currentDirection.x, 0, _currentDirection.y) * _playerModel.Speed;

        velocity = ApplyGravity(velocity);

        velocity = _controller.transform.TransformDirection(velocity);
        
        _controller.Move(velocity * Time.deltaTime);
    }

    private Vector3 ApplyGravity(Vector3 velocity)
    {
        if (!_groundChecker.isGrounded())
            _currentYSpeed -= GRAVITY * Time.deltaTime;
        else
            _currentYSpeed = 0;
        
        velocity.y = _currentYSpeed;
        return velocity;
    }

    private void OnNewDirection(InputAction.CallbackContext context)
    {
        _currentDirection = context.ReadValue<Vector2>();
    }
}
