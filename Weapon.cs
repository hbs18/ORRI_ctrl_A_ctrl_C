//ide u Player gameobject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Transform FirePoint;   //ovo postavi na firepoint!
    [SerializeField] GameObject BulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        Debug.Log("Shoot");
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
