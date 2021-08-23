using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alerts : MonoBehaviour
{
    public GameObject mainPlayer;
    public GameObject teammatePlayer;
    public GameObject enemyPlayer1;
    public GameObject enemyPlayer2;

    public Text healthy_mainPlayer;
    public Text healthy_teammatePlayer;
    public Text healthy_enemyPlayer1;
    public Text healthy_enemyPlayer2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int p1 = mainPlayer.GetComponent<PlayerAttributes>().health;
        int p2 = teammatePlayer.GetComponent<PlayerAttributes>().health;
        int p3 = enemyPlayer1.GetComponent<PlayerAttributes>().health;
        int p4 = enemyPlayer2.GetComponent<PlayerAttributes>().health;
        if (p1 < 0) {
            p1 = 0;
        }
        if (p2 < 0)
        {
            p2 = 0;
        }
        if (p3 < 0)
        {
            p3 = 0;
        }
        if (p4 < 0)
        {
            p4 = 0;
        }
        healthy_mainPlayer.text = "Me: " + p1;
        healthy_teammatePlayer.text = "My Teammate: " + p2;
        healthy_enemyPlayer1.text = "Enemy 1: " + p3;
        healthy_enemyPlayer2.text = "Enemy 2: " + p4;
    }
}
