using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    [Range(1f, 25f)]
    private float _speed = 1f;

    [SerializeField]
    [Range(0f, 8f)]
    private float _angularInterpolation = 1f;

    private void Start() => Cursor.lockState = CursorLockMode.Locked;
    

    void FixedUpdate()
    {
        Vector3 direction = CalculateDirection();

        Move(direction);
    }

    private Vector3 CalculateDirection()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var forward = _camera.transform.forward;
        forward.y = 0f;
        forward.Normalize();

        var direction = forward * vertical + horizontal * _camera.transform.right;

        return direction;
    }

    private void Move(Vector3 direction) => _rigidbody.velocity = direction.normalized*_speed;
        private void OnDestroy() => Cursor.lockState = CursorLockMode.None;
}

