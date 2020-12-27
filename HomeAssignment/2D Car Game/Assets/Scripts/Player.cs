using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f; 

    float xMin, xMax;

    float padding = 0.65f;

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
}
