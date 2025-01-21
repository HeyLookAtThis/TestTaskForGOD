using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private void Awake()
    {
        _spawner.Initialize();
        _spawner.Run();
    }
}
