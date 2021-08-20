using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMotion : MonoBehaviour
{
    private NavMeshAgent agent;
    //public GameObject startPoint;
    //public GameObject endPoint;
    public GameObject currentPlayer;
    public GameObject followedPlayer;
    public bool followMainPlayer = true;
    int changePosition = 30;
    int currentPositionCount = 0;

    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject gun4;

    private GameObject pickedGun = null;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(followedPlayer.GetComponent<PlayerAttributes>().health);

        if (currentPlayer.GetComponent<PlayerAttributes>().isAlive)
        {
            if (!currentPlayer.GetComponent<PlayerAttributes>().hasGun)
            {
                float pickedGunDistance = 9999999;
                if (gun1.activeSelf)
                {
                    if (Vector3.Distance(gun1.transform.position, currentPlayer.transform.position) < pickedGunDistance)
                    {
                        pickedGunDistance = Vector3.Distance(gun1.transform.position, currentPlayer.transform.position);
                        pickedGun = gun1;
                    }
                }
                if (gun2.activeSelf)
                {
                    if (Vector3.Distance(gun2.transform.position, currentPlayer.transform.position) < pickedGunDistance)
                    {
                        pickedGunDistance = Vector3.Distance(gun1.transform.position, currentPlayer.transform.position);
                        pickedGun = gun2;
                    }
                }
                if (gun3.activeSelf)
                {
                    if (Vector3.Distance(gun3.transform.position, currentPlayer.transform.position) < pickedGunDistance)
                    {
                        pickedGunDistance = Vector3.Distance(gun1.transform.position, currentPlayer.transform.position);
                        pickedGun = gun3;
                    }
                }
                if (gun4.activeSelf)
                {
                    if (Vector3.Distance(gun4.transform.position, currentPlayer.transform.position) < pickedGunDistance)
                    {
                        pickedGunDistance = Vector3.Distance(gun1.transform.position, currentPlayer.transform.position);
                        pickedGun = gun4;
                    }
                }
                agent.SetDestination(pickedGun.transform.position);

                if (pickedGun.transform.position.x == currentPlayer.transform.position.x &&
                    pickedGun.transform.position.z == currentPlayer.transform.position.z)
                {
                    pickedGun.SetActive(false);
                    currentPlayer.transform.GetChild(currentPlayer.transform.childCount-1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    currentPlayer.GetComponent<PlayerAttributes>().hasGun = true;
                    //Debug.Log();
                }
            }

            else if (followMainPlayer)
            {
                if (currentPositionCount % changePosition == 0)
                {
                    System.Random rnd = new System.Random();
                    int x = rnd.Next(10, 30);
                    int z = rnd.Next(10, 30);
                    agent.SetDestination(new Vector3(followedPlayer.transform.position.x + x,
                        agent.transform.position.y,
                        followedPlayer.transform.position.z + z));
                }

            }
            else
            {
                if (currentPositionCount % changePosition == 0)
                {
                    System.Random rnd = new System.Random();
                    int x = rnd.Next(0, 10);
                    int z = rnd.Next(0, 10);
                    agent.SetDestination(new Vector3(followedPlayer.transform.position.x + x,
                        agent.transform.position.y,
                        followedPlayer.transform.position.z + z));
                }
            }
        }
        currentPositionCount++;
    }
    
}
