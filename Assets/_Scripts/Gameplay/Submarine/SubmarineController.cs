using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SubmarineModel))]
[RequireComponent(typeof(Floater))]
public class SubmarineController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private SubmarineModel _model;
    
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private Floater _floater;
    
    private Vector2 _currentDirection;
    private float _depthDelta;

    private void OnValidate()
    {
        _rigidbody ??= GetComponent<Rigidbody>();
        _floater ??= GetComponent<Floater>();
    }

    public void SetMoveDirection(Vector2 direction) => _currentDirection = direction;

    public void SetDepth(float depthDelta) => _depthDelta = depthDelta;
    
    private void Start()
    {
        _rigidbody.centerOfMass = _model.CenterOfMass.localPosition;
    }
    
    private void FixedUpdate()
    {
        _model.ChangeTargetDepth(_depthDelta);
        _floater.Float(_model.DepthBeforeSubmerged);
        MoveSubmarine();
    }

    private void MoveSubmarine()
    {
        Vector3 linearVelocity = Vector3.forward * 
                                 (_currentDirection.y * _floater.buoyancyProperties.waterDrag * _model.Speed);
        
        Vector3 angularVelocity = Vector3.up * 
                                  (_currentDirection.x * 
                                   _floater.buoyancyProperties.waterAngularDrag * 
                                   _model.AngularSpeed * 
                                   Mathf.Clamp01(transform.InverseTransformDirection(_rigidbody.linearVelocity).z));
        
        _rigidbody.AddRelativeForce(linearVelocity, ForceMode.VelocityChange);
        _rigidbody.AddRelativeTorque(angularVelocity, ForceMode.VelocityChange);
    }

    public void SetFrowardDirection(float coeff)
    {
        _currentDirection.y = _model.Speed * coeff * Time.fixedDeltaTime;
    }

    public void SetAngularDirection(float coeff)
    {
        _currentDirection.x = _model.Speed * coeff * Time.fixedDeltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.TransformPoint(_rigidbody.centerOfMass), 0.25F);
    }
}
