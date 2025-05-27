using UnityEngine;
using UnityEngine.UI;

public class WaterEffectController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Image img;
    [SerializeField] Color defaultColor;
    [SerializeField] private Transform depthOrigin;
    [SerializeField] private float depth = 1f;

    private void Update()
    {
        img.color = Color.Lerp(img.color, ProjMath.Depth(depthOrigin) > depth ?
            defaultColor : new Color(img.color.r, img.color.g, img.color.b, 0f), speed * Time.deltaTime);
    }
}
