using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProperties", menuName = "Game/InputSettings")]
public class InputSettings : ScriptableObject
{
    [SerializeField]
    private float _MouseSensitivityX;
    [SerializeField]
    private float _MouseSensitivityY;

    public float MouseSensitivityX => _MouseSensitivityX;

    public float MouseSensitivityY => _MouseSensitivityY;
}
