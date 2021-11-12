using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumidityBar : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private Gradient _gradient;

    private float _humidity;
    private const float _maxHumidity = 100;

    void Start()
    {
        _humidity = 0;

        Scarecrow.UpdateHumidity += OnGetHumidity;

        OnGetHumidity(_humidity);
    }

    void OnGetHumidity(float humidity)
    {
        _bar.fillAmount = humidity / _maxHumidity;

        _bar.color = _gradient.Evaluate(_bar.fillAmount);
    }

    private void OnDestroy()
    {
        Scarecrow.UpdateHumidity -= OnGetHumidity;
    }
}
