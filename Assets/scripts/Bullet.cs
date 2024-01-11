using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 touchPos;
    private Camera mainCam;
    private float deltaX, deltaY, rotX, rotY;

    private Rigidbody2D rb;
    public float force;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
      
        GameObject playerObject = GameObject.Find("Player");
        player = playerObject.transform;
        Vector2 playerPos = Camera.main.ScreenToWorldPoint(player.position);

        rb = GetComponent<Rigidbody2D>();
        if(Input.touchCount > 0) {
            // Touch touch = Input.GetTouch(0);

            // Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            deltaX = playerPos.x - transform.position.x;
            deltaY = playerPos.y - transform.position.y;

            rotX = transform.position.x - playerPos.x;
            rotY = transform.position.y - playerPos.y;

            rb.velocity = new Vector2(deltaX - playerPos.x, deltaY - playerPos.y).normalized * force;
            float rot = Mathf.Atan2(rotX , rotY ) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot * 90);


            // switch(touch.phase){
            //     case TouchPhase.Began:
                    
            //         break;

            //     case TouchPhase.Moved:
            //         rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
            //         break;

            //     case TouchPhase.Ended:
            //         rb.velocity = Vector2.zero;
            //         break;
            // }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
