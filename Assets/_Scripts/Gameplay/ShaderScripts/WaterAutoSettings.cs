using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

public class WaterAutoSettings : MonoBehaviour
{
    private static readonly int _phaseID = Shader.PropertyToID("_Phase");
    private static readonly int _gravityID = Shader.PropertyToID("_Gravity");
    private static readonly int _waterDepthID = Shader.PropertyToID("_WaveDepth");
    private static readonly int _amplitudesID = Shader.PropertyToID("_Amplitudes");
    private static readonly int _timeScalesID = Shader.PropertyToID("_TimeScales");
    
    private static readonly int _direction1ID = Shader.PropertyToID("_Direction1");
    private static readonly int _direction2ID = Shader.PropertyToID("_Direction2");
    private static readonly int _direction3ID = Shader.PropertyToID("_Direction3");
    private static readonly int _direction4ID = Shader.PropertyToID("_Direction4");
    
    
    [SerializeField] private ShaderWaterSettings _shaderWaterSettings;
    [SerializeField] private Material _waterMaterial;

    [Button]
    public void ApplySettings()
    {
        _waterMaterial.SetFloat(_phaseID, _shaderWaterSettings.Phase);
        _waterMaterial.SetFloat(_gravityID, _shaderWaterSettings.Gravity);
        _waterMaterial.SetFloat(_waterDepthID, _shaderWaterSettings.WaveDepth);
        
        _waterMaterial.SetVector(_amplitudesID, _shaderWaterSettings.WaveAmplitude);
        _waterMaterial.SetVector(_timeScalesID, _shaderWaterSettings.TimeScale);
        
        _waterMaterial.SetVector(_direction1ID, _shaderWaterSettings.Direction1);
        _waterMaterial.SetVector(_direction2ID, _shaderWaterSettings.Direction2);
        _waterMaterial.SetVector(_direction3ID, _shaderWaterSettings.Direction3);
        _waterMaterial.SetVector(_direction4ID, _shaderWaterSettings.Direction4);
        
    }
}
