using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTMonoBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Start()
    {
        // For override
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void ResetValue()
    {
        // For override
    }

    protected virtual void LoadComponents()
    {
        // For ovrerride
    }
}
