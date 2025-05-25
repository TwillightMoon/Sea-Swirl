using UnityEngine;
using UnityEngine.Serialization;

public class PayloadSystem : MonoBehaviour
{
    [SerializeField]
    private Gun _gun;
    [SerializeField]
    private GameObject _torpedoesPreview;
    
    private bool _isLoaded = false;
    public bool isClosed = false;
    
    private void HideTorpedoesPreview()
    {
        _torpedoesPreview.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out TorpedoBlank blank))
            TorpedoProcessing(blank);
    }
    
    public void Shoot()
    {
        if(!_isLoaded || !isClosed) return;
        _isLoaded = false;
        
        _gun.Shoot();
        HideTorpedoesPreview();
    }

    private void TorpedoProcessing(TorpedoBlank torpedo)
    {
        torpedo.ResetPos();
        _torpedoesPreview.SetActive(true);
        
        _gun.LoadAmmo();
        _isLoaded = true;
    }
}
