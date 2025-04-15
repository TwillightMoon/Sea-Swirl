using System;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField]
    private Vector2 levelClampsAngles = new(0F, 90F);
    
    private Quaternion _originalRotation;

    private void Start()
    {
        _originalRotation = transform.localRotation;
    }

    public void RotateLevel(float target)
    {
        var angle = Mathf.Lerp(levelClampsAngles.x, levelClampsAngles.y, target);
        
        transform.localRotation = _originalRotation * Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
