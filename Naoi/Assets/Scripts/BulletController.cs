using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody bullet;
    public float speed  = 20f;
    float timer = 4f;
    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        bullet.velocity = transform.forward * speed;
        BulletTimer();
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);    
    }

    void BulletTimer()
    {
        timer -= Time.deltaTime;
        if(timer<0)
        {
            Destroy(gameObject);
        }
    }

}
