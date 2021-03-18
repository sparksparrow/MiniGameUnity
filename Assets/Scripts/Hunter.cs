using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Hunter : MonoBehaviour
{
    private Player _player;

    [SerializeField]
    private NavMeshAgent _agent;

    [SerializeField]
    public AudioSource _audioSource;

    [SerializeField]
    public AudioClip arrivalSound;

    private float _distanceAttack = 2.25f;

    void Start()
    {
        _audioSource.PlayOneShot(arrivalSound);
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        _agent.SetDestination(_player.transform.position);

        if (Vector3.Distance(_player.transform.position, transform.position)<=_distanceAttack)
        {
            Banana.RefreshLife();
            SceneManager.LoadScene("MenuScene");
        }

    }



}
