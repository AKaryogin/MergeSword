using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _coin;
    [SerializeField] private AudioSource _experience;
    [SerializeField] private AudioSource _merge;
    [SerializeField] private AudioSource _noFreeCells;

    public void PlayCoin()
    {
        _coin.Play();
    }

    public void PlayExperience()
    {
        _experience.Play();
    }

    public void PlayMerge()
    {
        _merge.Play();
    }

    public void PlayNoFreeCells()
    {
        _noFreeCells.Play();
    }
}
