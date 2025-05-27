using UnityEngine;

public class SonarLine : MonoBehaviour
{
    //Здесь расписана логика сонарной линии

    [SerializeField] private float speed;           //Скорость линии
    [SerializeField] private Transform rotatePoint; //Сам объект, который нужно крутить
    [SerializeField] private GameObject radarPoint; //Префаб временной точки, которая будет заспавнена когда линия каснется точки
    [SerializeField] private Transform sonar;       //Сам сонар

    private void OnTriggerEnter(Collider collision) //Тут при коллизии с точкой спавнится временная точка
    {
        if (!collision.TryGetComponent(out SonarPoint point)) return;
        GameObject obj = Instantiate(radarPoint, collision.transform.position, collision.transform.rotation, sonar);
        obj.GetComponent<SpriteRenderer>().color = point.Color;
        obj.GetComponent<SonarExpiringDot>().OriginalPoint = point.SonarPointPosition;
    }

    private void Update()
    {
        rotatePoint.eulerAngles += new Vector3(0, 0, 1) * speed * Time.deltaTime; //Само кручение линии
    }
}
