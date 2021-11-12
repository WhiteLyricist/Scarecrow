using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieryStone : Item
{
    [SerializeField] ParticleSystem _fire;

    internal override void StopUse()
    {
        _fire.gameObject.SetActive(false);
    }

    internal override void Use()
    {
        _fire.gameObject.SetActive(true);
    }
}
