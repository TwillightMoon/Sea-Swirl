using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Floater : MonoBehaviour
{
    [Header("anchor")]
    [SerializeField]
    private Transform[] _anchorPoints;
    
    [Header("Components")]
    [SerializeField]
    private Rigidbody _rigidbody;
    
    [SerializeField]
    private PhysWaterSettings _physWaterSettings;
    
    [SerializeField]
    private float _displacementAmount;
    
    private BuoyancyProperties _buoyancyProperties;
    
    public BuoyancyProperties buoyancyProperties => _buoyancyProperties;
    
    private float _currentWaveHeight;
    

    private void OnValidate()
    {
        _rigidbody ??= GetComponent<Rigidbody>();
    }
    
    public void Float(float targetDepth)
    {
        for (int i = 0; i < _anchorPoints.Length; i++)
            ProcessPoint(_anchorPoints[i], targetDepth);
    }

    private void ProcessPoint(Transform anchorPoint, float ballastValue)
    {
        ApplyGravity(anchorPoint);
        
        _currentWaveHeight = WaterManager.instance.GetWaveHeight(anchorPoint.position, Time.time);
        
        if(anchorPoint.position.y < 0) ApplyBuoyancy(anchorPoint, ballastValue);
    }

    private void ApplyGravity(Transform anchorPoint)
    {
        _rigidbody.AddForceAtPosition(Physics.gravity / _anchorPoints.Length, anchorPoint.position, ForceMode.Acceleration);
    }
    
    private void ApplyBuoyancy(Transform point,float targetDepth)
    {
        _buoyancyProperties = CalculateBuoyancyProperties(point, targetDepth);
        
        
        _rigidbody.AddForceAtPosition(Vector3.up * _buoyancyProperties.buoyancyForce, point.position, ForceMode.Acceleration);
        _rigidbody.AddForce(-_rigidbody.linearVelocity * _buoyancyProperties.waterDrag, ForceMode.VelocityChange);
        _rigidbody.AddTorque(-_rigidbody.angularVelocity * _buoyancyProperties.waterAngularDrag, ForceMode.VelocityChange);
    }

    private BuoyancyProperties CalculateBuoyancyProperties(Transform anchorPoint, float targetDepth)
    {
        float displacementMultiplier = Mathf.Clamp01((0 - anchorPoint.position.y) / targetDepth);
        float resultDisplacement = _displacementAmount * displacementMultiplier;
        
        float buoyancyForce = Mathf.Abs(Physics.gravity.y) * resultDisplacement;
        
        float rawDrag = resultDisplacement * Time.fixedDeltaTime;

        return new BuoyancyProperties(
                buoyancyForce, 
                rawDrag * _physWaterSettings.waterDrag, 
                rawDrag * _physWaterSettings.waterAngularDrag
                );
    }
}

public struct BuoyancyProperties
{
    public float buoyancyForce;
    
    public float waterDrag;
    public float waterAngularDrag;

    public BuoyancyProperties(float buoyancyForce, float waterDrag, float waterAngularDrag)
    {
        this.buoyancyForce = buoyancyForce;
        this.waterDrag = waterDrag;
        this.waterAngularDrag = waterAngularDrag;
    }
}
