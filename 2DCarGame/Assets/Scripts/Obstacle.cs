using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float health = 100;

    //reduces health whenever enemy collides with a gameObject which has DamageDealer component
    private void OnTriggerEnter2D(Collider2D other)
    {

        //access the Damage Dealer from the "other" object which hit the enemy
        //and depending on the damage reduce health

        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.GetDamage();
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
