using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _position;

    private void Update()
    {
        _position = _target.position;
        _position.y = 0;
        _position.z = -10;

        transform.position = Vector3.Lerp(transform.position, _position, 1 * Time.deltaTime);
    }
}
