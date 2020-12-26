using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private Transform[] _enemySpawnPoints;
    [SerializeField] private float _frequency = 2;

    private void Start()
    {
        _enemySpawnPoints = GetComponentsInChildren<Transform>();

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_frequency);

        while (true)
        {
            int randomIndex = Random.Range(0, _enemySpawnPoints.Length);

            Instantiate(_enemy, _enemySpawnPoints[randomIndex].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
