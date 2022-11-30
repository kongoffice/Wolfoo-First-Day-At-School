using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : CTMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 diretion = Vector3.left;

    void Update()
    {
        transform.parent.Translate(this.diretion * this.moveSpeed * Time.deltaTime);        
    }
}
