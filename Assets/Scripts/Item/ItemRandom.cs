using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandom : CTMonoBehaviour
{
    [SerializeField] protected ItemCtrl itemCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemCtrl();
    }

    protected virtual void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = GetComponent<ItemCtrl>();
        Debug.Log(transform.name + ": LoadItemCtrl", gameObject);
    }

    protected override void Start()
    {
        this.ItemSpawning();
    }

    protected virtual void ItemSpawning()
    {
        Transform ranPoint = this.itemCtrl.ItemSpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.itemCtrl.ItemSpawner.Spawn(ItemSpawner.uiitemOne, pos, rot);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.ItemSpawning), 1f);
    }
}
