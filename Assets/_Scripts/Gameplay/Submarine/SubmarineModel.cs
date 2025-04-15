using NaughtyAttributes;
using UnityEngine;

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
    [SerializeField]
    private float _depthBeforeSubmerged = 1;
    [SerializeField, Min(0.01F)]
    private float _depthStep = 0.1F;
    
    public Transform CenterOfMass => _centerOfMass;
    
    public float Speed => _speed;
    public float AngularSpeed => _angularSpeed;

    [Header("Depth controller")]
    public float DepthBeforeSubmerged => _depthBeforeSubmerged;
    
    public void ChangeTargetDepth(float delta)
    {
        _depthBeforeSubmerged -= delta * _depthStep * Time.fixedDeltaTime;
        _depthBeforeSubmerged = Mathf.Max(0.5F, _depthBeforeSubmerged);
    }
}
