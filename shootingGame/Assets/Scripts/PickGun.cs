using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickGun : MonoBehaviour
{
    public GameObject gunGrass;
    public GameObject gunPlayer;

    // Start is called before the first frame update
    void Start()
    {
	/*
        System.Random rnd= new System.Random();
        int x = rnd.Next(1, 13);
        int y = rnd.Next(1, 13);
        int z = rnd.Next(1, 13);

        gunGrass.transform.position = new Vector3(x, y, z);
	*/
    }

    private void OnMouseDown()
    {
        gunGrass.SetActive(false);
        gunPlayer.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
