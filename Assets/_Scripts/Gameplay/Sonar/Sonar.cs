using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    [SerializeField] private SonarPoint sonarPointPrefab;
    [SerializeField] private TextMeshProUGUI depthText;
    [SerializeField] private TextMeshProUGUI targetsText;
    [SerializeField] private string endScene = "End";
    [SerializeField] private SceneSwitcher sceneSwitcher;

    private List<SonarObject> objects = new List<SonarObject>();
    private List<DestroyableObject> destroyableObjects = new List<DestroyableObject>(); 

    private void Awake()
    {
        SonarObject.OnSonarObjectSpawn += AddNewPoint;
    }

    private void OnDisable()
    {
        SonarObject.OnSonarObjectSpawn -= AddNewPoint;
    }

    private void AddNewPoint(SonarObject obj, Color color)
    {
        objects.Add(obj);
        if (obj.gameObject.TryGetComponent(out DestroyableObject desObj)) destroyableObjects.Add(desObj);

        Instantiate(sonarPointPrefab, transform).TryGetComponent(out SonarPoint sonarPoint);

        sonarPoint.SonarPointPosition = obj.transform;
        sonarPoint.OriginPosition = transform;
        sonarPoint.Color = color;
        obj.OnSonarObjectDestroy += sonarPoint.OnPointDestroy;
    }

    private void Update()
    {
        depthText.text = "Depth: " + ProjMath.Depth(transform).ToString();

        int cnt = destroyableObjects.Count;
        foreach (DestroyableObject desObj in destroyableObjects)
        {
            if (desObj == null)
            {
                cnt -= 1;
            }
        }

        if (cnt <= 0)
        {
            enabled = false;
            sceneSwitcher.ChangeScene(endScene);
        }

        targetsText.text = "Targets left: " + cnt.ToString();
    }
}
