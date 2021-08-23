using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject mainPlayer;
    public GameObject enemyPlayer1;
    public GameObject enemyPlayer2;

    public Text EndText;

    private string endGameText = "";
    // Start is called before the first frame update
    void Start()
    {
        EndText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        int mainPlayer_health = mainPlayer.GetComponent<PlayerAttributes>().health;
        int enemyPlayer1_health = enemyPlayer1.GetComponent<PlayerAttributes>().health;
        int enemyPlayer2_health = enemyPlayer2.GetComponent<PlayerAttributes>().health;

        if (enemyPlayer1_health <= 0 && enemyPlayer2_health <= 0)
        {
            endGameText = "Victory";
            StartCoroutine(goToOpenPage());
        }
        else if (mainPlayer_health <= 0)
        {
            endGameText = "Loser";
            StartCoroutine(goToOpenPage());
        }

    }

    IEnumerator goToOpenPage()
    {
        EndText.text = endGameText;
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(0);
    }
}
