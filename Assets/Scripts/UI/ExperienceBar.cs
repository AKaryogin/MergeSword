using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Slider _bar;
    [SerializeField] private Experience _experience;

    private void OnEnable()
    {
        _bar.value = _experience.GetExperience;
        _levelText.text = _experience.Level.ToString();
        _experience.Added += OnAdded;
        _experience.Upped += OnUpped;
    }

    private void OnDisable()
    {
        _experience.Added -= OnAdded;
        _experience.Upped -= OnUpped;
    }

    private void OnAdded(int value)
    {
        _bar.value = value;
    }

    private void OnUpped(int value)
    {
        _levelText.text = value.ToString();
    }
}
