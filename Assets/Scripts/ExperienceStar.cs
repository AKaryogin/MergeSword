using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExperienceStar : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Sound _sound;
    [SerializeField] private Experience _experience;
    [SerializeField] private float _durationMove;

    public void CreateStar(Vector3 createPoint)
    {
        GameObject gameObject = _spawner.Spawn(_template, createPoint);
        gameObject.transform.DOMove(_targetPoint.position, _durationMove);
        StartCoroutine(DelayDestroy(gameObject, _durationMove));
    }

    private IEnumerator DelayDestroy(GameObject gameObject, float _duration)
    {
        yield return new WaitForSeconds(_duration);

        _experience.AddExperience();
        _sound.PlayExperience();
        Destroy(gameObject);
    }
}
