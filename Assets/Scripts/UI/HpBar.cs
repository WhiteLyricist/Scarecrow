using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Image _bar;

    private const float _maxhp = 1000;
    private float _hp;
  
    void Start()
    {
        _hp = _maxhp;

        Scarecrow.UpdateHp += OnGetDamage;

        OnGetDamage(_hp);
    }

    void OnGetDamage(float hp) 
    {
        _bar.fillAmount = hp / _maxhp;
    }

    private void OnDestroy()
    {
        Scarecrow.UpdateHp -= OnGetDamage;
    }
}
