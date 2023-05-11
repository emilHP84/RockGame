using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMouvementCamera : MonoBehaviour
{
    [Header("camera")]
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    [Header("vitesse")]
    [SerializeField] private float Speed;

    private bool _isOnContact;

    private void FixedUpdate() {
        if (_isOnContact == true) {
            cam.transform.position += new Vector3(1, 0, 0) * Speed * Time.deltaTime;
            
            if (cam.transform.position.x - player.transform.position.x > 0.001f) {
                _isOnContact = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            _isOnContact = true;
        }
    }
}
