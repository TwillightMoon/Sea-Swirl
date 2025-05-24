using System;
using UnityEngine;

public class PayloadSystem : MonoBehaviour
{
    [SerializeField]
    private Gun _gun;
    [SerializeField]
    private GameObject _torpedoesPreview;
    
    private bool _isLoaded = false;
    
    private void HideTorpedoesPreview()
    {
        _torpedoesPreview.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent(out TorpedoBlank blank)) return;
        
        blank.ResetPos();
        _torpedoesPreview.SetActive(true);
        
        _gun.LoadAmmo();
        _isLoaded = true;
    }

    public void Shoot()
    {
        if(!_isLoaded) return;
        _isLoaded = true;
        
        _gun.Shoot();
        HideTorpedoesPreview();
    }
}
