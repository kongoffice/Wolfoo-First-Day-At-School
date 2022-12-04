using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByDitance
{
    protected override void DespawnObject()
    {
        ItemSpawner.Intance.Despawn(transform.parent);
    }
}
