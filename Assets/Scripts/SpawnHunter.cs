using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHunter : MonoBehaviour
{

    [SerializeField]
    private Hunter _hunter;

    private System.Random _rand = new System.Random();

    const int RANDOM_SPAWN_POSTION = 49;

    private double currentTimeSpawn = 400;

    private double timeBeforeSpawn;

    private void Start()
    {
        Instantiate(_hunter, new Vector3(_rand.Next(-RANDOM_SPAWN_POSTION, RANDOM_SPAWN_POSTION), 1, _rand.Next(-RANDOM_SPAWN_POSTION, RANDOM_SPAWN_POSTION)), Quaternion.identity);
        timeBeforeSpawn = currentTimeSpawn;
    }
    void Update()
    {
        timeBeforeSpawn--;

        if (timeBeforeSpawn <= 0)
        {
            Instantiate(_hunter, new Vector3(_rand.Next(-RANDOM_SPAWN_POSTION, RANDOM_SPAWN_POSTION), 1, _rand.Next(-RANDOM_SPAWN_POSTION, RANDOM_SPAWN_POSTION)), Quaternion.identity);
            currentTimeSpawn *= 1.5;
            timeBeforeSpawn = currentTimeSpawn;
        }
    }
}
