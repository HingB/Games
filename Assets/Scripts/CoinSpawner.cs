using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(5);

        while (true)
        {
            Instantiate(_coin, _points[Random.Range(0, _points.Length)].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
