using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMotion : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject startPoint;
    public GameObject endPoint;
    bool goBack = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!goBack)
        {
            agent.SetDestination(startPoint.transform.position);
            if (agent.transform.position.x == startPoint.transform.position.x &&
                agent.transform.position.z == startPoint.transform.position.z)
            {
                goBack = true;
            }
        } else
        {
            agent.SetDestination(endPoint.transform.position);
            if (agent.transform.position.x == endPoint.transform.position.x &&
                agent.transform.position.z == endPoint.transform.position.z)
            {
                goBack = false;
            }
        }
    }
}
