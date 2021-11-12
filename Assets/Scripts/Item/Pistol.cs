using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Item
{
    [SerializeField] private GameObject _bulletsPrefab;

    private GameObject _bullet;

    internal override void StopUse()
    {
        
    }

    internal override void Use()
    {

        _bullet = Instantiate(_bulletsPrefab) as GameObject;
        _bullet.transform.position = transform.TransformPoint(new Vector3(0, 0.12f, 0.1f));
        _bullet.transform.rotation = transform.rotation;
        _bullet.transform.Rotate(90f, 0, 0);

    }
}
