using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnnemies : MonoBehaviour
{
    public int maxHealth;
    public int actualHeatlh;
    
    public int damage;
    public int damageTake;

    public void Start() {
        actualHeatlh = maxHealth;
    }

    private void Update() {
        if (actualHeatlh <= 0){
            Dead();
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ammunition") {
            damageTake = other.GetComponent<BulletsBasic>().Damage;
            Damage();
        }
    }

    void Damage() {
        actualHeatlh -= damageTake;
    }

    void Dead() {
        gameObject.SetActive(false);
    }
}
