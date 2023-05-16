using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Life : MonoBehaviour
{
    public int maxHealth;
    public int actualHealth;

    public bool invulnerability;
    public float invulnerabilityTime;
    public GameObject invulnerabilityBubble;

    public int damageTake;

    void Start() {
        actualHealth = maxHealth;
        invulnerability = false;
        invulnerabilityTime = 0;
        invulnerabilityBubble.SetActive(false);
    }
    
    void Update() {
        invulnerabilityTime += Time.deltaTime;
        if (invulnerability == true && invulnerabilityTime <= 3) {
            invulnerabilityBubble.SetActive(true);
        }

        if (invulnerability == true && invulnerabilityTime > 3) {
            invulnerabilityBubble.SetActive(false);
            invulnerability = false;
        }

        if (actualHealth <= 0) {
            Dead();
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (invulnerability == false) {
            if (other.tag == "Ennemie") {
                damageTake = other.GetComponent<LifeEnnemies>().damage;
                Damage();
            }
        }
    }

    void Damage() {
        invulnerabilityTime = 0;
        actualHealth -= damageTake;
        invulnerability = true;
    }

    void Dead() {
        gameObject.SetActive(false);
    }
}
