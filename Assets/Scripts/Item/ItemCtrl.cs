using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : CTMonoBehaviour 
{
    [SerializeField] protected ItemSpawner itemSpawner;

    public  ItemSpawner ItemSpawner { get => itemSpawner; }

    [SerializeField] protected ItemSpawnPoints itemSpawnPoints;

    public ItemSpawnPoints ItemSpawnPoints { get => itemSpawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSpawner();
        this.LoadItemSpawnPoints();
    }

    protected virtual void LoadItemSpawner()
    {
        if (this.itemSpawner != null) return;
        this.itemSpawner = GetComponent<ItemSpawner>();
        Debug.Log(transform.name + ": LoadItemSpawner", gameObject);
    }

    protected virtual void LoadItemSpawnPoints()
    {
        if (this.itemSpawnPoints != null) return;
        this.itemSpawnPoints = GetComponent<ItemSpawnPoints>();
        Debug.Log(transform.name + ": LoadItemSpawnPoints", gameObject);
    }
}
