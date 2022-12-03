using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandom : CTMonoBehaviour
{
    [Header("Item Random")] 
    [SerializeField] protected ItemCtrl itemCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;

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

    protected virtual void FixedUpdate()
    {
        this.ItemSpawning();
    }

    protected virtual void ItemSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform ranPoint = this.itemCtrl.ItemSpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform prefab = this.itemCtrl.ItemSpawner.RandomPrefab();
        Transform obj = this.itemCtrl.ItemSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.ItemSpawning), 1f);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentItem = this.itemCtrl.ItemSpawner.SpawnedCount;
        return currentItem >= this.randomLimit;
    }
}
