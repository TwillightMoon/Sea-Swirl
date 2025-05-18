using UnityEngine;

public class SonarPoint : MonoBehaviour
{
    [SerializeField] private float posMultiplier;
    public Transform SonarPointPosition { get; set; }
    public Transform OriginPosition { get; set; }
    public Color Color { get; set; }

    private void Update()
    {
        if (SonarPointPosition == null) return;
        transform.localPosition = new Vector3(SonarPointPosition.position.x - OriginPosition.position.x,
            SonarPointPosition.position.z - OriginPosition.position.z, 0f) * posMultiplier; 
    }

    public void OnPointDestroy()
    {
        Destroy(gameObject);
    }
}
