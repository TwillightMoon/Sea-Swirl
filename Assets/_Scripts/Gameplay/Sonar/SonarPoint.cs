using UnityEngine;

public class SonarPoint : MonoBehaviour
{
    //Здесь прописана логика точки на сонаре, постоянно прикрепленная к объекту

    [SerializeField] private float posMultiplier;       //Множитель позиции. 1 в данном случае будет показывать на сонаре в соотношении 1 к 1
    public Transform SonarPointPosition { get; set; }   //Позиция объекта, к которому прикреплена точка
    public Transform OriginPosition { get; set; }       //Позиция подводной лодки
    public Color Color { get; set; }                    //Передаваемый цвет точки для линии

    private void Update()
    {
        if (SonarPointPosition == null) return;
        transform.localPosition = new Vector3(SonarPointPosition.position.x - OriginPosition.position.x,
            SonarPointPosition.position.z - OriginPosition.position.z, 0f) * posMultiplier; // Берем направление от подлодки то объекта, на которого указывает точка.
    }

    public void OnPointDestroy() //Метод который подписывается на уничтожение оригинального объекта. Чтобы точка на сонаре пропала вместе с объектом
    {
        Destroy(gameObject);
    }
}
