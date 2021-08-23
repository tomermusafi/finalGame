using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStartLocation : MonoBehaviour
{
    public GameObject center;

    public GameObject grenadeBox1;
    public GameObject grenadeBox2;
    public GameObject grenadeBox3;
    public GameObject grenadeBox4;

    public GameObject gunBox1;
    public GameObject gunBox2;
    public GameObject gunBox3;
    public GameObject gunBox4;

    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    static Vector3 GetTerrainPos(float x, float z)
    {
        //Create object to store raycast data
        RaycastHit hit;

        //Create origin for raycast that is above the terrain. I chose 100.
        Vector3 origin = new Vector3(x, 100, z);

        //Send the raycast.
        Physics.Raycast(origin, Vector3.down, out hit, Mathf.Infinity);

        Debug.Log("Terrain location found at " + hit.point);
        return hit.point;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objects = {
            grenadeBox1,
            grenadeBox2,
            grenadeBox3,
            grenadeBox4,

            gunBox1,
            gunBox2,
            gunBox3,
            gunBox4,

            player2,
            player3,
            player4
        };

        System.Random rnd = new System.Random();
        int count = 0;
        foreach (GameObject o in objects)
        {
            int x = rnd.Next(0, 20);
            int z = rnd.Next(0, 20);

            int minusx = rnd.Next(0, 2);
            int minusz = rnd.Next(0, 2);

            if (minusx == 0)
            {
                x *= -1;
            }

            if (minusz == 0)
            {
                z *= -1;
            }

            o.transform.position = GetTerrainPos(center.transform.position.x + x, center.transform.position.z + z);
            if (count > 8)
            {
                o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y + 30, o.transform.position.z);
            }
            else
            {
                o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y + 100, o.transform.position.z);
            }
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
