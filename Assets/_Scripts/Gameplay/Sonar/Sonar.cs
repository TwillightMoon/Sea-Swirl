using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    [SerializeField] private SonarPoint sonarPointPrefab;

    private List<SonarObject> objects = new List<SonarObject>();

    private void Awake()
    {
        SonarObject.OnSonarObjectSpawn += AddNewPoint;
    }

    private void OnDisable()
    {
        SonarObject.OnSonarObjectSpawn -= AddNewPoint;
    }

    private void AddNewPoint(SonarObject obj)
    {
        objects.Add(obj);

        Instantiate(sonarPointPrefab, transform).TryGetComponent(out SonarPoint sonarPoint);

        sonarPoint.SonarPointPosition = obj.transform;
        sonarPoint.OriginPosition = transform;
        obj.OnSonarObjectDestroy += sonarPoint.OnPointDestroy;
    }
}
