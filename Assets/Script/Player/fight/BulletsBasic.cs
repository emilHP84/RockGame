using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsBasic : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 direction;
    private Camera mainCam;

    public int Damage;
    
    public float SpeedBullets;
    public float timeBetweenDestroy;

    private float time;

    private void Start() {
        gameObject.transform.parent = null;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - transform.position;
    }
    private void Update() {
        time += Time.deltaTime;
        if (time >= timeBetweenDestroy) {
            Destroy(gameObject);
        }
    }
    void FixedUpdate() {
        gameObject.transform.position += new Vector3(direction.x,direction.y,0) * SpeedBullets * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
