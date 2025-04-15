using UnityEngine;
using UnityEngine.Serialization;

public class PlayerModel : MonoBehaviour
{
    [SerializeField]
    private InputSettings _inputSettings;
    
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _interactionRange;

    [SerializeField]
    private Vector2 _cameraLimitations = new Vector2(-90F, 90F);

    public InputSettings InputSettings => _inputSettings;

    public Vector2 CameraLimitations => _cameraLimitations;

    public float Speed => _speed;
    public float InteractionRange => _interactionRange;
    
    public float MouseSensitivityX => _inputSettings.MouseSensitivityX;
    public float MouseSensitivityY => _inputSettings.MouseSensitivityY;
}
