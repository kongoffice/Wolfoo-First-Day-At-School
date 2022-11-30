using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager intance;

    public static InputManager Intance { get => intance; }

    [SerializeField] protected Vector3 mouseWorldPos;

    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] protected float onMove;

    public float OnMove { get => onMove; }

    void Awake()
    {
        if (InputManager.intance != null) Debug.Log("Only 1 InpuManager allow to exist");
        InputManager.intance = this;
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
        }
    }
    
}
