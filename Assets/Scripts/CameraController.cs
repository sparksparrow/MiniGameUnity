using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    [Range(1f, 8f)]
    private float _interpolation = 1f;

    private Vector3 _offset;

    private void Start() => _offset = _rigidbody.position - _player.transform.position;

    void Update() => Move();
    private void Move() => _rigidbody.position = Vector3.Lerp(_rigidbody.position, _player.transform.position + _offset, _interpolation * Time.deltaTime);

}
