using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBananas : MonoBehaviour
{
    [SerializeField]
    private Banana _banana;    

    private int _frame = 0;

    private System.Random _rand = new System.Random();

    private int _spawnTime;

    const int MIN_SPAWN_TIME = 350;
    const int MAX_SPAWN_TIME = 500;
    const int RANDOM_SPAWN_POSTION = 49;
    const int MAX_SPAWN_ANGEL = 360;

    void Start()
    {
        SpawnBanana();
        _spawnTime = _rand.Next(MIN_SPAWN_TIME, MAX_SPAWN_TIME);
    }

    void Update()
    {
        _frame++;
        if (_frame == _spawnTime)
        {
            SpawnBanana();
            _frame = 0;
            _spawnTime = _rand.Next(MIN_SPAWN_TIME, MAX_SPAWN_TIME);
        }
    }

    private void SpawnBanana()
    {
        Instantiate(_banana, new Vector3(_rand.Next(-RANDOM_SPAWN_POSTION, RANDOM_SPAWN_POSTION), 1, _rand.Next(-RANDOM_SPAWN_POSTION, RANDOM_SPAWN_POSTION)), new Quaternion(_rand.Next(0, MAX_SPAWN_ANGEL), _rand.Next(0, MAX_SPAWN_ANGEL), _rand.Next(0, MAX_SPAWN_ANGEL), _rand.Next(0, MAX_SPAWN_ANGEL)));
    }
}
