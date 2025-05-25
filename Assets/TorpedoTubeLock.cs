using System;
using UnityEngine;

public class TorpedoTubeLock : MonoBehaviour
{
    [SerializeField]
    private PayloadSystem _payloadSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Hatch hatch))
            HatchProcessing(hatch, isClose: true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Hatch hatch))
            HatchProcessing(hatch, isClose:false);
    }

    private void HatchProcessing(Hatch component, bool isClose)
    {
        _payloadSystem.isClosed = isClose;
    }
}
