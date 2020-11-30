using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator _playerAnim;
    private float _speed = 1.2f;
    private float _rotateSpeed = 10;
    private Vector3 _startPlayerPosition;
    private Vector3 _startCameraPosition;

    float currentV = 0;
    float currentH = 0;
    Vector3 offsetDirection = Vector3.zero;

    private void Awake()
    {
        _playerAnim = GetComponent<Animator>();
        _startPlayerPosition = transform.position;
        _startCameraPosition = Camera.main.transform.position;
    }

    private void Update()
    {
        Move();
        CameraMove();
    }

    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Transform camera = Camera.main.transform;

        currentV = Mathf.Lerp(currentV, v, Time.deltaTime * _rotateSpeed);
        currentH = Mathf.Lerp(currentH, h, Time.deltaTime * _rotateSpeed);
        Vector3 direction = camera.forward * currentV + camera.right * currentH;

        float directionLenght = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLenght;

        if (direction != Vector3.zero)
        {
            offsetDirection = Vector3.Slerp(offsetDirection, direction, _rotateSpeed * Time.deltaTime);

            transform.position += offsetDirection * _speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(offsetDirection);

            _playerAnim.SetFloat("RunDirection", Mathf.Max(Mathf.Abs(v), Mathf.Abs(h)));
        }
    }

    private void CameraMove()
    {
        Camera.main.transform.position = transform.position - _startPlayerPosition + _startCameraPosition;
    }
}
