using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNPCMotion : MonoBehaviour
{
    private NavMeshAgent agent;
    //public GameObject startPoint;
    //public GameObject endPoint;
    public GameObject mainPlayer;
    bool followMainPlayer = true;
    int changePosition = 200;
    int currentPositionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mainPlayer.GetComponent<PlayerAttributes>().health);

        
        if (followMainPlayer && currentPositionCount % changePosition == 0)
        {
            System.Random rnd = new System.Random();
            int x = rnd.Next(1, 15);
            int y = rnd.Next(1, 15);
            int z = rnd.Next(1, 15);
            agent.SetDestination(new Vector3(mainPlayer.transform.position.x, mainPlayer.transform.position.y, mainPlayer.transform.position.z));

        } else
        {
            // follow secondary player
            // TODO - Add secondary player and logic
            /*agent.SetDestination(endPoint.transform.position);
            if (agent.transform.position.x == endPoint.transform.position.x &&
                agent.transform.position.z == endPoint.transform.position.z)
            {

            }
            */
        }

    }
}
