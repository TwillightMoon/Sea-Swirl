using UnityEngine;

public class TorpedoBlank : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;
    
    [SerializeField]
    private Transform _startPosition;

    public void ResetPos()
    {
        _rigidbody.position = _startPosition.position;
        _rigidbody.linearVelocity = Vector3.zero;
    }
}
