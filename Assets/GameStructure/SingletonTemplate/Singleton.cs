using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicate singletons
        }
        else
        {
            Instance = this as T;
            DontDestroyOnLoad(gameObject); // Keep across scene loads
        }
    }
}