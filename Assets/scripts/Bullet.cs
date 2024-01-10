using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 touchPos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        touchPos = mainCam.ScreenToWorldPoint(Input.GetTouch(0).position);
        Vector3 direction = touchPos - transform.position;
        Vector3 rotation = transform.position - touchPos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot * 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
