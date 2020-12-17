using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShoot : MonoBehaviour
{
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemylaserPrefab;
    [SerializeField] float enemyLaserSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        //every frame reduce the amount of time for shot
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            EnemyFire();
            //reset shot counter
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void EnemyFire()
    {
        //spawn an enemyLaser at enemy postion
        GameObject enemyLaser = Instantiate(enemylaserPrefab, transform.position, Quaternion.identity) as GameObject;

        //-speed shoot downwards
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyLaserSpeed);
    }
}
