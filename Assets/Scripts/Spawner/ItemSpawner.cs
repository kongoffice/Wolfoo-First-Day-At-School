using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    private static ItemSpawner intance;

    public static ItemSpawner Intance { get => intance; }

    public static string diabay = "dia bay";

    protected override void Awake()
    {
        base.Awake();
        if (ItemSpawner.intance != null) Debug.Log("Only 1 ItemSpawner allow to exist");
        ItemSpawner.intance = this;
    }

}
