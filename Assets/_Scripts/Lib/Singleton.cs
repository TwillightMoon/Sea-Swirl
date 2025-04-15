using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                if(!TryFindInstance())
                    CreateInstance();
            }
            return _instance;
        }
    }

    private static bool TryFindInstance()
    {
        _instance = FindFirstObjectByType<T>();
        
        return _instance != null;
    }
    
    private static void CreateInstance()
    {
        GameObject singletonObj = new GameObject(typeof(T).Name);

        _instance = singletonObj.AddComponent<T>();
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this as T;
        else
            Destroy(this);
    }
}
