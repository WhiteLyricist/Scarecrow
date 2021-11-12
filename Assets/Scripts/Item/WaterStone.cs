using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStone : Item
{
    [SerializeField] private GameObject _waterProjectilePrefab;

    private GameObject _waterProjectile;

    internal override void StopUse()
    {
        
    }

    internal override void Use()
    {
        _waterProjectile = Instantiate(_waterProjectilePrefab) as GameObject;
        _waterProjectile.transform.position = transform.TransformPoint(new Vector3(0, 0.2f, 0.1f));
        _waterProjectile.transform.rotation = transform.rotation;
        _waterProjectile.transform.Rotate(90f, 0, 0);
    }
}
