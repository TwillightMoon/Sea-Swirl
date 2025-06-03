using UnityEngine;

public class WindowCamera : MonoBehaviour
{
    [SerializeField] private Transform _windowTransform;
    [SerializeField] private Transform _mainCameraTransform;
    

    private void Update()
    {
        Vector3 lockerPos = _windowTransform.worldToLocalMatrix.MultiplyPoint3x4(_mainCameraTransform.transform.position);
        transform.localPosition = lockerPos;
        
        Quaternion difference = transform.rotation * Quaternion.Inverse(_windowTransform.rotation * Quaternion.Euler(Vector3.up * 180f));
        transform.rotation = difference * _windowTransform.rotation;
    }
}