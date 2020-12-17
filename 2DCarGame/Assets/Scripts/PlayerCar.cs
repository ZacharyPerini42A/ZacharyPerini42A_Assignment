using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] float health = 100f;


    float xMin, xMax;

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);



        transform.position = new Vector2(newXPos, transform.position.y);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }



    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //access the damage dealer class from "otherobject which hits enemy and reduces health accordingly"
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        if (!dmgDealer)//if dmgDealer == null
        {
            return;
        }

        ProcessHit(dmgDealer);
    }

    //whenever this is called send us the damagedealer details
    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();
        //destroy laser
        dmgDealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
