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
    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = transform.position - playerTransform.position;
        float rotZ = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
        transform.rotation = quaternion.Euler(0 , 0, rotZ);

        if(!canFire){
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring){
                canFire = true;
                timer = 0;
            }
        }

        if(Input.touchCount > 0 && canFire){
            canFire = false;
            Instantiate(bullet, playerTransform.position, Quaternion.identity);
        }

    }
}
