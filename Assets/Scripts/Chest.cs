using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour
{    
    [SerializeField] private Sword _sword;    

    public event UnityAction<GameObject> Placed;

    public Spawner Spawner { get; set; }

    public void CreateSword()
    {
        GameObject newSword = Spawner.Spawn(_sword.gameObject, transform.position, gameObject);
        Placed?.Invoke(newSword);
    }
}
