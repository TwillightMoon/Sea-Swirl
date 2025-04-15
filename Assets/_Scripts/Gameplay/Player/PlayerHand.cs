using PaleLuna.Interactable;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField]
    private PlayerModel _playerModel;
    [SerializeField]
    private LayerMask _leverLayer;

    private IGrippable _grippable = null;
    
    void Update()
    {
        if (_grippable == null)
            SelectGrippable();
        else
            ControllGrippable();
    }

    private void SelectGrippable()
    {
        // Луч из центра экрана
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _playerModel.InteractionRange, _leverLayer))
        {
            // Если нажали ЛКМ - "схватываем" рычаг
            if (Input.GetMouseButtonDown(0))
            {
                IGrippable lever = hit.collider.GetComponent<IGrippable>();
                if (lever != null)
                {
                    _grippable = lever;
                    _grippable.Interact();
                }
            }
            
        }
    }

    private void ControllGrippable()
    {
        if (Input.GetMouseButton(0))
            _grippable.Holding();
        else
        {
            _grippable.Ungrab();
            _grippable = null;
        }
    }
}
