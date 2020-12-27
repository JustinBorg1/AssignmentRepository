using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float ScrollSpeed = 0.2f;

    //material from the texture
    Material myMaterial;

    Vector2 offSet;


    // Start is called before the first frame update
    void Start()
    {
        //getting background material from Renderer component
        myMaterial = GetComponent<Renderer>().material;

        //move with the given speed on the y-axis
        offSet = new Vector2(0f, ScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //move the material by offSet every frame
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
