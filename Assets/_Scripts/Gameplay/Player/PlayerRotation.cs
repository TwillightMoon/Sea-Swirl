using UnityEngine;

public class PlayerRotation : MouseReader
{
    private PlayerModel _model;
    
    private Transform _cameraTransform;

    private Quaternion _bodyRotationOrigin;
    
    private float _rotX = 0.0f;
    private float _rotY = 0.0f;
    
    public PlayerRotation(PlayerModel model, Transform cameraTransform)
    {
        _model = model;
        _cameraTransform = cameraTransform;
        
        _bodyRotationOrigin = _model.transform.rotation;
    }

    public void Rotate()
    {
        _cameraTransform.localRotation = RotationAroundAxisX();
        _model.transform.rotation = _bodyRotationOrigin * RotationAroundAxisY();
    }

    private Quaternion RotationAroundAxisY()
    {
        _rotX += m_mouseDelta.x * Time.deltaTime * _model.MouseSensitivityX;
        return Quaternion.AngleAxis(_rotX, Vector3.up);
    }

    private Quaternion RotationAroundAxisX()
    {
        _rotY -= m_mouseDelta.y * Time.deltaTime * _model.MouseSensitivityY;
        
        _rotY = Mathf.Clamp(_rotY, _model.CameraLimitations.x, _model.CameraLimitations.y);
        
        return Quaternion.AngleAxis(_rotY, Vector3.right);
    }
    
    
}
