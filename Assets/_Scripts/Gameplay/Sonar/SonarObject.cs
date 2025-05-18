using System;
using System.Collections.Generic;
using UnityEngine;

public class SonarObject : MonoBehaviour
{
    public static Action<SonarObject> OnSonarObjectSpawn { get; set; }

    public Action OnSonarObjectDestroy { get; set; }

    private void Start()
    {
        OnSonarObjectSpawn?.Invoke(this);
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) return;
        OnSonarObjectDestroy?.Invoke();
    }
}