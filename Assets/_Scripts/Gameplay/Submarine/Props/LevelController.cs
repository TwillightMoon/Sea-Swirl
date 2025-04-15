using System;
using PaleLuna.Interactable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LevelView))]
public class LevelController : MonoBehaviour, IGrippable
{
    [SerializeField]
    private LevelView _levelView;
    
    [SerializeField]
    private LevelAxisMode _levelAxisMode;

    [SerializeField]
    private float _startValue = 0.5F;
    [SerializeField]
    private float _levelMultpl = 1;

    [SerializeField]
    private float _clampToZero = 0.05F;
    
    [SerializeField]
    private UnityEvent<float> onValueChanged; 
    
    private Vector3 _currentMouseDelta;
    private float _value;

    private void OnValidate()
    {
        _levelView ??= GetComponent<LevelView>();
    }

    private void Start()
    {
        _value = _startValue;   
    }

    public void Interact()
    {
        PlayerInputReader.instance.GetAction(PlayerInputKeys.Mouse).performed += ReadMouseDelta;
        PlayerInputReader.instance.GetAction(PlayerInputKeys.Mouse).canceled += ReadMouseDelta;
    }

    public void Holding()
    {
        _value += (_levelAxisMode == LevelAxisMode.LevelAbscissa ?  _currentMouseDelta.x : _currentMouseDelta.y) * _levelMultpl * Time.deltaTime;
        
        if(Mathf.Abs(_value) < _clampToZero) _value = 0;
        
        _value = Mathf.Clamp(_value, -1, 1);
        
        _levelView.RotateLevel((_value + 1) / 2);
        
        onValueChanged?.Invoke(_value);
    }

    public void Ungrab()
    {
        PlayerInputReader.instance.GetAction(PlayerInputKeys.Mouse).performed -= ReadMouseDelta;
        PlayerInputReader.instance.GetAction(PlayerInputKeys.Mouse).canceled -= ReadMouseDelta;
    }

    private void ReadMouseDelta(InputAction.CallbackContext context) => 
        _currentMouseDelta = context.ReadValue<Vector2>();
}

public enum LevelAxisMode
{
    LevelAbscissa,
    LevelOrdinate 
}
