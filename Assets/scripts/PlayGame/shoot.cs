using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform playerTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    private float rotX, rotY;

    private Camera mainCamera;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        //
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0 , 0, rotZ);
        
        if(Input.touchCount > 0) 
        {
            // Touch touch = Input.GetTouch(0);

            // Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);


            // rotX = touchPos.x - transform.position.x;
            // rotY = touchPos.y - transform.position.y;
            // float rotZ = Mathf.Atan2(rotX, rotY) * Mathf.Rad2Deg;
            // transform.rotation = quaternion.Euler(0 , 0, rotZ);

            if(!canFire){
                timer += Time.deltaTime;
                if(timer > timeBetweenFiring){
                    canFire = true;
                    timer = 0;
                }
            }

            if(canFire){
                canFire = false;
                Instantiate(bullet, playerTransform.position, Quaternion.identity);
            }
        }
        

    }
}
