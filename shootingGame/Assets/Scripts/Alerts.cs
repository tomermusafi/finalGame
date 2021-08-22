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
        healthy_mainPlayer.text = "Me: " + mainPlayer.GetComponent<PlayerAttributes>().health;
        healthy_teammatePlayer.text = "My Teammate: " + teammatePlayer.GetComponent<PlayerAttributes>().health;
        healthy_enemyPlayer1.text = "Enemy 1: " + enemyPlayer1.GetComponent<PlayerAttributes>().health;
        healthy_enemyPlayer2.text = "Enemy 2: " + enemyPlayer2.GetComponent<PlayerAttributes>().health;
    }
}
