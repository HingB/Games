using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _constYPosition = 0, _constZPosition = -10;
    [SerializeField] private Transform _target;

    private Vector3 _position;

    private void Update()
    {
        _position = _target.position;
        _position.y = _constYPosition;
        _position.z = _constZPosition;

        transform.position = Vector3.Lerp(transform.position, _position, 1 * Time.deltaTime);
    }
}
