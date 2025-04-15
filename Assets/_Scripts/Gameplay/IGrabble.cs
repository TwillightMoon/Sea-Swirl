using UnityEngine;

namespace PaleLuna.Interactable
{
    public interface IGrippable : IInteractable
    {
        public void Holding();
        public void Ungrab();
    }
}
