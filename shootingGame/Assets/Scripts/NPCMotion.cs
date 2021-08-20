using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNPCMotion : MonoBehaviour
{
    private NavMeshAgent agent;
    //public GameObject startPoint;
    //public GameObject endPoint;
    public GameObject followedPlayer;
    public bool followMainPlayer = true;
    int changePosition = 30;
    int currentPositionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(followedPlayer.GetComponent<PlayerAttributes>().health);

        
        if (followMainPlayer)
        {
            if (currentPositionCount % changePosition == 0)
            {
                System.Random rnd = new System.Random();
                int x = rnd.Next(1, 10);
                int z = rnd.Next(1, 10);
                agent.SetDestination(new Vector3(followedPlayer.transform.position.x + x,
                    agent.transform.position.y,
                    followedPlayer.transform.position.z + z));
            }

        } else
        {
            if (currentPositionCount % changePosition == 0)
            {
                System.Random rnd = new System.Random();
                int x = rnd.Next(1, 10);
                int z = rnd.Next(1, 10);
                agent.SetDestination(new Vector3(followedPlayer.transform.position.x + x,
                    agent.transform.position.y,
                    followedPlayer.transform.position.z + z));
            }
        }
        currentPositionCount++;
    }
}
