using UnityEngine;

[CreateAssetMenu(fileName = "WaterSettings", menuName = "Game/WaterSettings")]
public class PhysWaterSettings : ScriptableObject
{
    [Header("Physical Settings")]
    [SerializeField]
    private float _waterDrag = 0.99F;
    [SerializeField]
    private float _waterAngularDrag = 0.5F;
    
    public float waterDrag => _waterDrag;
    public float waterAngularDrag => _waterAngularDrag;
}
