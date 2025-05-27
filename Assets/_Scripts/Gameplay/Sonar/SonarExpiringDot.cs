using TMPro;
using UnityEngine;

public class SonarExpiringDot : MonoBehaviour
{
    //Здесь расписана логика временной точки, появляющейся когда сонарная линия касается точки на сонаре

    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float dissapearSpeed;          //Скорость уменьшения альфа канала объекта
    [SerializeField] private float destroyAlpha = 0.01f;    //На каком уровне альфа канала объект уничтожается

    public Transform OriginalPoint { get; set; }            //Позиция получаемая при спавне, которая указывает на оригинальный объект. Нужна для глубины

    private void Update()
    {
        spr.color = Color.Lerp(spr.color, new Color(spr.color.r, spr.color.g, spr.color.b, 0f), Time.deltaTime * dissapearSpeed);       //Логика исчезновения
        text.color = Color.Lerp(text.color, new Color(text.color.r, text.color.g, text.color.b, 0f), Time.deltaTime * dissapearSpeed);  //Исчезновение также и текста

        if (OriginalPoint != null) text.text = "Depth: " + ProjMath.Depth(OriginalPoint).ToString();

        if (spr.color.a < destroyAlpha) Destroy(gameObject);
    }
}
