using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepawnByDitance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Camera mainCam;

    protected virtual void FixedUpdate()
    {
        this.Despawning();
    }

    protected override void LoadComponents()
    {
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>();
        Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    }

    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }

    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

    protected override void CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position);
    }

}
