using UnityEngine;

namespace Script.Platform
{
public class SpawnPlatform : Platform
{
    [SerializeField] private Ball.Ball _ball;
    [SerializeField] private Transform _spawnPoint;

    private void Awake()
    {
        Instantiate(_ball, _spawnPoint.position, Quaternion.identity);
    }
}
}
