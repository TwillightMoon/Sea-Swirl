using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

public class SubmarineModel : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField]
    public Transform _centerOfMass;
    
    [Header("Mobility")]
    [SerializeField]
    private float _speed = 10.0F;
    [SerializeField]
    private float _angularSpeed = 5.0F;

    [Header("Depth controller")]
    [SerializeField, Min(0.5F)]
    private float _minDepthBeforeSubmerged = 0.5f;

    [SerializeField]
    private float _depthBeforeSubmerged = 1;
    [SerializeField, Min(0.01F)]
    private float _depthStep = 0.1F;
    
    [Header("Ballast")]
    [SerializeField, Range(0.25F, 100.0F)]
    private float _maxWeightOfBallasts = 0.2F;
    
    private float _minWeightOfBallast = 0.0F;

    private float _weightOfFirstBallast;
    private float _weightOfSecondBallast;
    
    public Transform CenterOfMass => _centerOfMass;
    
    public float Speed => _speed;
    public float AngularSpeed => _angularSpeed;

    [Header("Depth controller")]
    public float DepthBeforeSubmerged => _depthBeforeSubmerged;

    public void FillFirstBallast(float delta)
    {
        _weightOfFirstBallast -= delta * _depthStep * Time.fixedDeltaTime;
        _weightOfFirstBallast = Mathf.Clamp(_weightOfFirstBallast, _minWeightOfBallast, _maxWeightOfBallasts);
        
        print(_weightOfFirstBallast);
    }
    public void FillSecondBallast(float delta)
    {
        _weightOfSecondBallast -= delta * _depthStep * Time.fixedDeltaTime;
        _weightOfSecondBallast = Mathf.Clamp(_weightOfSecondBallast, _minWeightOfBallast, _maxWeightOfBallasts);
    }
    
    public void ChangeTargetDepth()
    {
        _depthBeforeSubmerged = _weightOfFirstBallast + _weightOfSecondBallast;
        _depthBeforeSubmerged = Mathf.Max(_minDepthBeforeSubmerged, _depthBeforeSubmerged);
    }
}
