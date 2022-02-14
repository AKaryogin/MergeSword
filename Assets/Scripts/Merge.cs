using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Merge : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private Sound _sound;
    [SerializeField] private GameObject _coinIcon;
    [SerializeField] private float _duration;
    [SerializeField] private Sword[] _swords;

    private void OnEnable()
    {
        _clickHandler.Merged += OnMerge;
    }
    private void OnDisable()
    {
        _clickHandler.Merged -= OnMerge;
    }

    private void OnMerge(Sword swordOrigin, Sword swordMerge)
    {
        swordOrigin.Collider2D.enabled = false;
        swordMerge.transform.position = swordOrigin.transform.position;
        swordMerge.transform.Rotate(new Vector3(0, 0, 90));
        swordMerge.SpriteRenderer.flipX = false;

        GameObject newSword = _spawner.Spawn(_swords[swordOrigin.Rank].gameObject, swordOrigin.transform.position, swordOrigin.transform.parent.gameObject);

        if(newSword.GetComponent<Sword>().IsMaxRank)
            StartCoroutine(SetCoinIcon(_duration, newSword));

        _sound.PlayMerge();
        Destroy(swordOrigin.gameObject, .5f);
        Destroy(swordMerge.gameObject, .5f);
        BounceEffect(newSword, _duration);
    }

    private void BounceEffect(GameObject gameObject, float duration)
    {
        gameObject.transform.localScale = Vector3.zero;
        gameObject.transform.DOScale(new Vector3(1, 1, 0), duration);
    }

    private IEnumerator SetCoinIcon(float duration, GameObject sword)
    {
        yield return new WaitForSeconds(duration);

        _spawner.Spawn(_coinIcon, sword.transform.position + _coinIcon.transform.position, sword);       
    }
}
