using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Spawn(GameObject template, Vector3 position)
    {
        return Instantiate(template, position, Quaternion.identity);
    }

    public GameObject Spawn(GameObject template, Vector3 position, GameObject container)
    {
        GameObject gameObject = Instantiate(template, container.transform);
        gameObject.transform.position = position;
        
        return gameObject;
    }
}
