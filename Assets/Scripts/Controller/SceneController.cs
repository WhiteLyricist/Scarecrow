using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _prefScarecrow;

    private GameObject _scarecrow;
 
    void Start()
    {
        _scarecrow = Instantiate(_prefScarecrow) as GameObject;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            if (_scarecrow != null)
            {
                Destroy(_scarecrow);
                _scarecrow = Instantiate(_prefScarecrow) as GameObject;
            }
            else 
            {
                _scarecrow = Instantiate(_prefScarecrow) as GameObject;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }
}
