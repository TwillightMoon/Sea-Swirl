using TMPro;
using UnityEngine;

public class SonarExpiringDot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float dissapearSpeed;
    [SerializeField] private float destroyAlpha = 0.01f;

    public Transform OriginalPoint { get; set; }

    private void Update()
    {
        spr.color = Color.Lerp(spr.color, new Color(spr.color.r, spr.color.g, spr.color.b, 0f), Time.deltaTime * dissapearSpeed);
        text.color = Color.Lerp(text.color, new Color(text.color.r, text.color.g, text.color.b, 0f), Time.deltaTime * dissapearSpeed);

        if (OriginalPoint != null) text.text = "Depth: " + ProjMath.Depth(OriginalPoint).ToString();

        if (spr.color.a < destroyAlpha) Destroy(gameObject);
    }
}
