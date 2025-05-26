using UnityEngine;

public class SonarLine : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform rotatePoint;
    [SerializeField] private GameObject radarPoint;
    [SerializeField] private Transform sonar;

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.TryGetComponent(out SonarPoint point)) return;
        GameObject obj = Instantiate(radarPoint, collision.transform.position, collision.transform.rotation, sonar);
        obj.GetComponent<SpriteRenderer>().color = point.Color;
        obj.GetComponent<SonarExpiringDot>().OriginalPoint = point.SonarPointPosition;
    }

    private void Update()
    {
        rotatePoint.eulerAngles += new Vector3(0, 0, 1) * speed * Time.deltaTime;
    }
}
