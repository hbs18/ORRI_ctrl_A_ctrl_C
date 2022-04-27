using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D body;
    //private float jumpSpeed = 10;
    [SerializeField] float jumpSpeed;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            source.PlayOneShot(clip);

        }
        transform.rotation = Quaternion.Euler(0f, 0f, body.velocity.y * 2f);    //rotacija po Z osi ovisno o Y-os brzini tijela 
    }

    private void OnTriggerEnter2D(Collider2D collision) //kad player uðe u collider od barriera. treba didat collider na playera i is trigger checkbox. na bariere treba dodat isto collider (oni nisu trigger)
    {
        SceneManager.LoadScene(0);
    }
}
