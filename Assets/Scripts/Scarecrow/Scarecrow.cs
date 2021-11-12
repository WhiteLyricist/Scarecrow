using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    [SerializeField] private Renderer _rendererBody;
    [SerializeField] private Renderer _rendererClothing;

    public static Action<float> UpdateHp = delegate { };
    public static Action<float> UpdateHumidity = delegate { };

    public enum ScarecrowState { Dry, Wet, Burning };

    public ScarecrowState CurrentState = ScarecrowState.Dry;

    private int _hp;
    private int _humidity;

    private Color _startColor;

    private bool _fire = false;

    void Start()
    {
        _hp = 1000;
        _humidity = 0;

        _startColor = _rendererBody.material.color;
    }

    void FireDamage() 
    {
        _fire = true;
        Damage(5, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>()) 
        {
            switch (CurrentState) 
            {
                case ScarecrowState.Dry:
                    Damage(20, 0);
                    break;
                case ScarecrowState.Wet:
                    Damage(10, 0);
                    break;
                case ScarecrowState.Burning:
                    Damage(30, 0);
                    break;
            }

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.GetComponent<WaterProjectile>()) 
        {
            if (CurrentState != ScarecrowState.Burning)
            {
                Damage(0, 10);
            }
            else 
            {
                Damage(0, 1);
            }

            Destroy(collision.gameObject);

        }
    }
    private void OnParticleCollision(GameObject other)
    {
        _fire = false;
        Damage(1,-1);
    }

    void Damage(int damage, int humidity) 
    {
        _hp -= damage;
        _humidity += humidity;

        UpdateHumidity(_humidity);
        UpdateHp(_hp);

        if (_hp <= 0) 
        {
            Destroy(gameObject);
        }

        _humidity = Mathf.Clamp(_humidity, -1, 100);

        if (_humidity == -1 && _fire == false) 
        {
            _fire = true;
            CurrentState = ScarecrowState.Burning;
            _rendererBody.material.color = Color.red;
            _rendererClothing.material.color = Color.red;

            StopAllCoroutines();
            CancelInvoke();
            StartCoroutine(BurningScarecrow());
            InvokeRepeating("FireDamage", 0.1f, 1f);
        }
        if (_humidity == 0) 
        {
            CurrentState = ScarecrowState.Dry;
            _rendererBody.material.color = _startColor;
            _rendererClothing.material.color = _startColor;

            StopAllCoroutines();
            CancelInvoke();
        }
        if (_humidity > 0)
        {
            CurrentState = ScarecrowState.Wet;
            _rendererBody.material.color = Color.blue;
            _rendererClothing.material.color = Color.blue;

            StopAllCoroutines();
            CancelInvoke();
        }

    }

    private IEnumerator BurningScarecrow()
    {

        yield return new WaitForSeconds(10f);

        CancelInvoke();

        _fire = false;

        _humidity = 0;
        CurrentState = ScarecrowState.Dry;
        _rendererClothing.material.color = _startColor;
        _rendererBody.material.color = _startColor;
    }
}
