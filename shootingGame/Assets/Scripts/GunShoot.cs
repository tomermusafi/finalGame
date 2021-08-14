using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject target;
    public GameObject aCamera;
    private AudioSource sound;
    public GameObject aGun;
    // Start is called before the first frame update
    void Start()
    {
        sound = aGun.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("shoot"))
        {
            sound.Play();
            Debug.Log("shoot");
            
            RaycastHit hit;
            Debug.Log(Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit));
            if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
            {
                target.transform.position = hit.point;
                Debug.Log("dddd");

            }
        }

    }
}
