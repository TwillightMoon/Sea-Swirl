using UnityEngine;
using UnityEngine.InputSystem;

public abstract class MouseReader
{
    protected Vector2 m_mouseDelta;
    
    public void SubscribeToReader()
    {
        PlayerInputReader.instance.GetAction(PlayerInputKeys.Mouse).performed += ReadMouseDelta;
        PlayerInputReader.instance.GetAction(PlayerInputKeys.Mouse).canceled += ReadMouseDelta;
    }

    public void UnsubscribeFromReader()
    {
        PlayerInputReader.instance.GetAction(PlayerInputKeys.Mouse).performed -= ReadMouseDelta;
        PlayerInputReader.instance.GetAction(PlayerInputKeys.Mouse).canceled -= ReadMouseDelta;
    }

    private void ReadMouseDelta(InputAction.CallbackContext context)
    {
        m_mouseDelta = context.ReadValue<Vector2>();
    }
}
