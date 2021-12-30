using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoSingleton<PipeController>
{
    [SerializeField] private float spawnInterval;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private float minHeight,maxHeight;
    public float Speed;

    
    private void Start() 
    {
        GameController.Instance.StartGame += () => StartCoroutine(nameof(SpawnRoutine));
    }

    private IEnumerator SpawnRoutine()
    {
        while(true)
        {
            var obj = objectPool.GetPooledObject();
            obj.transform.position = new Vector2(transform.position.x,Random.Range(minHeight,maxHeight));
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}
