using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Money : MonoBehaviour
{    
    private int _money = 0;

    public event UnityAction<int> Added;

    public int GetMoney => _money;

    public void AddMoney(int money)
    {
        _money += money;
        Added?.Invoke(_money);
    }
}
