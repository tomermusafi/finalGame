using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System;

public class PickGun : MonoBehaviour
{
    public GameObject gunGrass;
    public GameObject gunPlayer;

    public GameObject currentPlayer;

    // Start is called before the first frame update
    void Start()
    {

        //mainPlayer.GetComponent<PlayerProperties>().health = 10000000;

        //mainPlayer.GetComponent<PlayerAttributes>().health = 10000000;
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
        Debug.Log("SDFSDF");
        gunGrass.SetActive(false);
        gunPlayer.SetActive(true);
        if (gunPlayer.transform.gameObject.name.Contains("Glock"))
        {
            currentPlayer.GetComponent<PlayerAttributes>().hasGun = true;
        } 
        else if (gunPlayer.transform.gameObject.name.Contains("Grenade"))
        {
            currentPlayer.GetComponent<PlayerAttributes>().hasGrenade = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
