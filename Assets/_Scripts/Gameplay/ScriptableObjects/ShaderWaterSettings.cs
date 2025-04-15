using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ShaderWaterSettings", menuName = "ShadersSettings/ShaderWaterSettings")]
public class ShaderWaterSettings : ScriptableObject
{
    [Header("Wave settings")]
    [SerializeField]
    private float _phase = 1;
    [SerializeField]
    private float _gravity = 9;

    [SerializeField]
    private float _waveDepth = 1;
    [FormerlySerializedAs("_waveApmlitude")] [SerializeField]
    private Vector4 _waveAmplitude = new Vector4(0.02F,0.2F,0.55F,0.37F);
    
    [SerializeField]
    private Vector4 _timeScale = new Vector4(1F,25F,10F,50F);

    [Header("Wave directions")]
    [SerializeField]
    private Vector3 _direction1;
    [SerializeField]
    private Vector3 _direction2;
    [SerializeField]
    private Vector3 _direction3;
    [SerializeField]
    private Vector3 _direction4;

    public float Phase => _phase;

    public float Gravity => _gravity;

    public float WaveDepth => _waveDepth;

    public Vector4 WaveAmplitude => _waveAmplitude;

    public Vector4 TimeScale => _timeScale;

    public Vector3 Direction1 => _direction1;

    public Vector3 Direction2 => _direction2;

    public Vector3 Direction3 => _direction3;

    public Vector3 Direction4 => _direction4;
}
