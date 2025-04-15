using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]
    private float _radius;
    
    [SerializeField]
    private LayerMask _groudnMask;


    public bool isGrounded()
    {
        return Physics.CheckSphere(transform.position, _radius, _groudnMask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0.58f, 0.89f);
        
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
