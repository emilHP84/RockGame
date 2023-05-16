using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    
    public GameObject Bullets;
    public Transform bulletTransform;
    
    private Camera mainCamera;
    private Vector3 mousePos;

    private void Start() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update() {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0,0, rotZ);
        
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(Bullets, bulletTransform.position, Quaternion.identity);
        }
    }
}
