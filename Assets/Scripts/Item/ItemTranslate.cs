using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ItemTranslate : CTMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 diretion = Vector3.left;

    protected override void Start()

    {
        StartCoroutine(IETranslate());
        
    }

    IEnumerator IETranslate()
    {
        while (true)
        {
            transform.Translate(-5*Time.deltaTime ,0 ,0);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        
    }
}
