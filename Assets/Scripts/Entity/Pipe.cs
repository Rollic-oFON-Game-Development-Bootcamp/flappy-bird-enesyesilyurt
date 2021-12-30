using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.left* PipeController.Instance.Speed * Time.deltaTime);
    }
}
