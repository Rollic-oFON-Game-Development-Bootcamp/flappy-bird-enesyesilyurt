using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> pooledObjects;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;
    
    private void Awake()
    {
            pooledObjects = new Queue<GameObject>();
            for (int j = 0; j < poolSize; j++)
            {
                GameObject obj = Instantiate(objectPrefab);
                obj.SetActive(false);
                pooledObjects.Enqueue(obj);
            }
    }

    public GameObject GetPooledObject()
    {
        GameObject obj = pooledObjects.Dequeue();
        obj.SetActive(true);
        pooledObjects.Enqueue(obj);
        return obj;
    }
}