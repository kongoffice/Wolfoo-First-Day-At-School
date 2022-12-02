using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaBayDepawn : DespawnByDitance
{
    protected override void DespawnObject()
    {
        DiaBayDepawn.Intance.Despawn(transform.parent);
    }
}
