using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theif : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
    }
}
