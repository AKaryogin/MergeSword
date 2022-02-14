using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Sound _sound;
    [SerializeField] private Money _money;
    [SerializeField] private float _durationMove;

    public void CreateCoin(Vector3 createPoint, int cost)
    {
        GameObject gameObject = _spawner.Spawn(_template, createPoint);
        gameObject.transform.DOMove(_targetPoint.position, _durationMove);
        StartCoroutine(DelayDestroy(gameObject, _durationMove, cost));
    }

    private IEnumerator DelayDestroy(GameObject gameObject, float _duration, int cost)
    {
        yield return new WaitForSeconds(_duration);

        _money.AddMoney(cost);
        _sound.PlayCoin();
        Destroy(gameObject);
    }
}
