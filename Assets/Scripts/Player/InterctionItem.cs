using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Hand
{
    public Item item;
    public Transform palm;
}

public class InterctionItem : MonoBehaviour
{
    private Camera _camera;

    private float _lengthRay = 2.5f;

    [SerializeField] private Hand _handLeft;
    [SerializeField] private Hand _handRight;

    private void Start()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_handLeft.item == null)
            {
                _handLeft.item = ToRaiseItem(_handLeft.palm);
            }
            else 
            {
                _handLeft.item = _handLeft.item.Drop(_handLeft.palm);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_handRight.item == null)
            {
                _handRight.item = ToRaiseItem(_handRight.palm);
            }
            else
            {
               _handRight.item = _handRight.item.Drop(_handRight.palm);
            }
        }
        if (Input.GetMouseButtonDown(0) && _handLeft.item != null) { _handLeft.item.Use(); }
        if (Input.GetMouseButtonDown(1) && _handRight.item != null) { _handRight.item.Use(); }
        if (Input.GetMouseButtonUp(0) && _handLeft.item != null) { _handLeft.item.StopUse(); }
        if (Input.GetMouseButtonUp(1) && _handRight.item != null) { _handRight.item.StopUse(); }
    }


    Item ToRaiseItem(Transform palm) 
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

        Ray ray = _camera.ScreenPointToRay(point);

        RaycastHit hit;

        Physics.Raycast(ray, out hit, _lengthRay);

        if (hit.collider != null && hit.collider.GetComponent<Item>() != null)
        {
            
            return hit.collider.GetComponent<Item>().Equip(palm);
 
        }
        else return null;
    }
}
