using UnityEngine;

public class SonarExpiringDot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private float dissapearSpeed;
    [SerializeField] private float destroyAlpha = 0.01f;

    private void Update()
    {
        spr.color = Color.Lerp(spr.color, new Color(spr.color.r, spr.color.g, spr.color.b, 0f), Time.deltaTime * dissapearSpeed);
        if (spr.color.a < destroyAlpha) Destroy(gameObject);
    }
}
