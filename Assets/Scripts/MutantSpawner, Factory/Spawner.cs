using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Range(1, 6)] private int _mutantCount; 
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private MutantFactory _mutantFactory;

    private List<Transform> _emtySpawnPoints;

    public void Initialize() => _emtySpawnPoints = new List<Transform>(_spawnPoints);

    public void Run()
    {
        int mutantCreated = 0;

        while (mutantCreated < _mutantCount)
        {
            Mutant mutant = _mutantFactory.Get((MutantType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(MutantType)).Length));
            mutant.Transform.position = GetRandomCoordinate();
            mutantCreated++;
        }
    }

    private Vector2 GetRandomCoordinate()
    {
        Transform spawnPoint = _emtySpawnPoints[UnityEngine.Random.Range(0, _emtySpawnPoints.Count)];
        _emtySpawnPoints.Remove(spawnPoint);
        return spawnPoint.position;
    }
}
