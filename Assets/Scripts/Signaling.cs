using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTheifEnter;
    [SerializeField] private UnityEvent _onTheifExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _onTheifEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _onTheifExit.Invoke();
    }
}
