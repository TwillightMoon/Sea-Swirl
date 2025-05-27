using UnityEngine;

public class WindowCamera : MonoBehaviour
{
    [SerializeField] private Transform otherCam;
    [SerializeField] private Vector3 offset = new(-90f, 270f, -90f);

    private void Update()
    {
        //transform.rotation = otherCam.rotation;
    }
}