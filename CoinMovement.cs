using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{

    float randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(-5f, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin((Time.time*3)+randomNumber) / 300, transform.position.z);
    }
}

//pomicanje objekta (coina) gore dolje, randomly
//transform.position.x|y|z je trenutni polozaj objecta