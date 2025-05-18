using System;
using System.Collections.Generic;
using UnityEngine;

public class SonarObject : MonoBehaviour
{
    [SerializeField] private Color color;

    public static Action<SonarObject, Color> OnSonarObjectSpawn { get; set; }

    public Action OnSonarObjectDestroy { get; set; }

    private void Start()
    {
        OnSonarObjectSpawn?.Invoke(this, color);
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) return;
        OnSonarObjectDestroy?.Invoke();
    }
}