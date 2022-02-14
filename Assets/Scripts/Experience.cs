using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Experience : MonoBehaviour
{
    [SerializeField] private int _gainExperience;
    [SerializeField] private int _maxExperience;

    private int _level = 0;
    private int _experience = 0;

    public event UnityAction<int> Added;
    public event UnityAction<int> Upped;

    public int Level => _level;
    public int GetExperience => _experience;
    public int MaxExperience => _maxExperience;

    public void AddExperience()
    {
        if((_experience + _gainExperience) < _maxExperience)
        {
            _experience += _gainExperience;
            Added?.Invoke(_experience);
        }
        else
        {
            _level++;
            _experience += _gainExperience;
            _experience -= _maxExperience;

            Added?.Invoke(_experience);
            Upped?.Invoke(_level);
        }
    }
}
