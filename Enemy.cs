// ide u enemy object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void die(){
        Destroy(gameObject);
    }
}
