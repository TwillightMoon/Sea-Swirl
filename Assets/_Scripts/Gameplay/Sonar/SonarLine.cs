using UnityEngine;

public class SonarLine : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform rotatePoint;
    [SerializeField] private GameObject radarPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<SonarPoint>()) return;
        Instantiate(radarPoint, collision.transform.position, collision.transform.rotation);
    }

    private void Update()
    {
        rotatePoint.eulerAngles += new Vector3(0, 0, 1) * speed * Time.deltaTime;
    }
}
