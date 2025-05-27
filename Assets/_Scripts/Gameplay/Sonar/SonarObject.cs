using System;
using System.Collections.Generic;
using UnityEngine;

public class SonarObject : MonoBehaviour
{
    //Здесь расписана логика любого объекта, который отображается на сонаре

    [SerializeField] private Color color; //Цвет объекта на сонаре

    public static Action<SonarObject, Color> OnSonarObjectSpawn { get; set; } //Событие, на которое позже подпишется 
                                                                              //сам сонар, для того, чтобы иметь информацию об это объекте
    public Action OnSonarObjectDestroy { get; set; }                          //Событие при уничтожении объекта

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