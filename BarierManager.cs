using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarierManager : MonoBehaviour
{
    [SerializeField] GameObject BarrierPrefab;
    private float lastTime = 0;
    private float spawnTime;


    // Update is called once per frame
    void Update()
    {
        spawnTime = 5f / (Time.time * 0.1f + 2.5f); //delay za spawnanje i povcanje brzije spawna

        if (Time.time - lastTime > spawnTime)   //Time.time koliko dugo traje igra
        {
            lastTime = Time.time;
            Vector3 spawnPos = new Vector3(8f, Random.Range(-5, 5), 0f);    //x, y, z koordinata. 8 float je daleko desno izvan kamere
            GameObject barrierInstance = Instantiate(BarrierPrefab, spawnPos, Quaternion.identity);
            barrierInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 0);     //x je -2, ide u ljevo. barijera prefab mora imati rigidbody2d component i gravityscale na 0 da ne pada dolje

        }
    }
}
