using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Camera cam;
    private Rigidbody2D rb2d;
    public float speed = 5.0f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
    public AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical); 
        rb2d.velocity = movement * speed;
    }

    private void Update()
    {
        Vector3 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad; // -90

        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);
        Debug.DrawLine(transform.position, mousePos, Color.white, Time.deltaTime); //For debugging purposes

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            Debug.Log("Mouse Clicked");
            GameObject Bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Bullet.transform.right * bulletSpeed;
            }

        }

    }

}
