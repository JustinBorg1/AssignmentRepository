using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] float moveSpeed = 10f; 

    float xMin, xMax;

    float padding = 0.65f;

    [SerializeField] AudioClip playerHitSound;
    [SerializeField] [Range(0, 1)] float playerHitSoundVolume = 0.75f;

    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

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

    public int getHealth()
    {
        return health;
    }

    //setting up the camera according to the boundaries
    private void SetUpMoveBoundaries()
    {
        
        Camera gameCamera = Camera.main;

        //xMin = 0, xMax = 1
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-padding;

    }

    private  void Move()
    {
        //deltaX is being updated with movement occuring on the x-axis
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        var newXPos = transform.position.x + deltaX;
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);
        
        //updates the position of the Player
        this.transform.position = new Vector2(newXPos, -5.75f);

    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();
        AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, playerHitSoundVolume);

        if (!dmgDealer)
        {
            return;
        }

        //instintiate explosion effect
        GameObject explosion = Instantiate(deathVFX, otherObject.transform.position, Quaternion.identity);
        Destroy(explosion, explosionDuration);

        ProcessHit(dmgDealer);

    }

    private void ProcessHit(DamageDealer dmg)
    {
        health -= dmg.GetDamage();

        dmg.Hit();

        if(health <= 0)
        {
            //make health = 0, so the healthText does not go below 0
            health = 0;

            //Play death audio
            AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);

            //spawn explosion particle at player position
            GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(explosion, explosionDuration);

            //destroy the player
            Destroy(gameObject);

            //load the gameOver scene
            FindObjectOfType<Level>().LoadGameOver();
        }
    }
}
