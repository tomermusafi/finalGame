using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCGunShoot : MonoBehaviour
{
    private LineRenderer lr;
    public GameObject muzzle;

    public GameObject currentPlayer;
    private AudioSource sound;
    private AudioSource sound2;
    public GameObject aGun;
    public GameObject target;

    public GameObject Enemy1;
    public GameObject Enemy2;
    private Animator anim1;
    private Animator anim2;

    public bool isNPC;

    private int countFramesCount = 0;
    private int whenToShootFrames;
    private int minusHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        sound = aGun.GetComponent<AudioSource>();
        anim1 = Enemy1.GetComponent<Animator>();
        anim2 = Enemy2.GetComponent<Animator>();
        sound2 = Enemy2.GetComponent<AudioSource>();
        System.Random rnd = new System.Random();
    }

    IEnumerator Shoot()
    {
        lr.SetPosition(0, muzzle.transform.position);
        lr.SetPosition(1, target.transform.position);
        sound.Play();
        lr.enabled = true;
        yield return new WaitForSeconds(0.1f);
        lr.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        // Logic to NPC
        countFramesCount++;
        if (currentPlayer.GetComponent<PlayerAttributes>().isAlive &&
            currentPlayer.GetComponent<PlayerAttributes>().hasGun &&
            isNPC &&
            countFramesCount % currentPlayer.GetComponent<PlayerAttributes>().whenToShootFrames == 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(currentPlayer.transform.position, currentPlayer.transform.forward, out hit))
            {
                GameObject pickedEnemy = null;
                float pickeEnemyDistance = 9999999;
                if (Enemy1.GetComponent<PlayerAttributes>().isAlive)
                {
                    if (Vector3.Distance(Enemy1.transform.position, currentPlayer.transform.position) < pickeEnemyDistance)
                    {
                        pickeEnemyDistance = Vector3.Distance(Enemy1.transform.position, currentPlayer.transform.position);
                        pickedEnemy = Enemy1;
                    }
                }

                if (Enemy2.GetComponent<PlayerAttributes>().isAlive)
                {
                    if (Vector3.Distance(Enemy2.transform.position, currentPlayer.transform.position) < pickeEnemyDistance)
                    {
                        pickeEnemyDistance = Vector3.Distance(Enemy1.transform.position, currentPlayer.transform.position);
                        pickedEnemy = Enemy2;
                    }
                }
                try
                {
                    if (!pickedEnemy.Equals(null))
                    {
                        currentPlayer.transform.LookAt(pickedEnemy.transform.position);
                        target.transform.position = hit.point;
                        StartCoroutine(Shoot());
                        pickedEnemy.GetComponent<PlayerAttributes>().health -= minusHealth;
                        if(pickedEnemy.GetComponent<PlayerAttributes>().num == 4)
                            sound2.Play();
                        if (pickedEnemy.GetComponent<PlayerAttributes>().health <= 0)
                        {
                            if (!pickedEnemy.GetComponent<PlayerAttributes>().isMainPlayer)
                            {
                                pickedEnemy.GetComponent<NavMeshAgent>().enabled = false;
                                pickedEnemy.GetComponent<PlayerAttributes>().isAlive = false;
                            }
                        }
                        //Debug.Log($"Hit enemy {pickedEnemy.transform.gameObject.name}");
                    }
                }
                catch
                {

                }
            }
        }
    }
}