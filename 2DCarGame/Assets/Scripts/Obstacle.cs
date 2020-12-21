using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;
    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] [Range(0, 1)] float enemyDeathSoundVolume = 0.75f;

    private float hit;


    //reduces health whenever enemy collides with a gameObject which has DamageDealer component
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.GetDamage();

        if (health <= 0)
        {
           Die();
        }
    }
           


    private void Die()
    {
        Destroy(gameObject);
        //create an explosion particle
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //destroy after 1 sec
        Destroy(explosion, 1f);
        AudioSource.PlayClipAtPoint(enemyDeathSound, Camera.main.transform.position, enemyDeathSoundVolume);
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
