using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class VRLever : MonoBehaviour
{
    public HingeJoint hinge;
    [Range(-1,1)] public float value;
    public UnityEvent<float> onValueChanged;

    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        hinge = GetComponent<HingeJoint>();

        // Можно настроить тип движения:
        // grabInteractable.movementType = XRBaseInteractable.MovementType.Instantaneous;
    }

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        // Начать обновлять значение
        enabled = true;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        // Остановить обновления
        enabled = false;
    }

    void Update()
    {
        // Текущий угол рычага от HingeJoint
        float angle = hinge.angle; 
        // Нормируем угол из [min,max] в [–1,1]
        var lim = hinge.limits;
        float norm = Mathf.InverseLerp(lim.min, lim.max, angle) * 2f - 1f;
        value = Mathf.Clamp(norm, -1f, 1f);
        onValueChanged?.Invoke(value);
    }
}