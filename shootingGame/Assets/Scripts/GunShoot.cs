using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunShoot : MonoBehaviour
{
    private LineRenderer lr;
    public GameObject muzzle;

    public GameObject currentPlayer;
    private AudioSource sound;
    public GameObject aGun;
    public GameObject target;

    public GameObject Enemy1;
    public GameObject Enemy2;
    private Animator anim1;
    private Animator anim2;

    public bool isNPC;
    int countFramesCount = 0;
    int whenToShootFrames = 100;
    int minusHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        sound = aGun.GetComponent<AudioSource>();
        anim1 = Enemy1.GetComponent<Animator>();
        anim2 = Enemy2.GetComponent<Animator>();

        System.Random rnd = new System.Random();
        whenToShootFrames = rnd.Next(30, 100);
    }

    IEnumerator Shoot()
    {
        lr.SetPosition(0, muzzle.transform.position);
        lr.SetPosition(1, target.transform.position);
        sound.Play();
        lr.enabled = true;
        yield return new WaitForSeconds(0.01f);
        lr.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        // Logic to NPC
        countFramesCount++;
        try
        {
            if (currentPlayer.GetComponent<PlayerAttributes>().hasGun &&
                isNPC &&
                countFramesCount % whenToShootFrames == 0)
            {
                RaycastHit hit;
                if (Physics.Raycast(currentPlayer.transform.position, currentPlayer.transform.forward, out hit))
                {
                    target.transform.position = hit.point;
                    StartCoroutine(Shoot());

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

                    if (!pickedEnemy.Equals(null))
                    {
                        pickedEnemy.GetComponent<PlayerAttributes>().health -= minusHealth;
                        if (pickedEnemy.GetComponent<PlayerAttributes>().health <= 0)
                        {
                            if (!pickedEnemy.GetComponent<PlayerAttributes>().isMainPlayer)
                            {
                                pickedEnemy.GetComponent<NavMeshAgent>().enabled = false;
                                pickedEnemy.GetComponent<PlayerAttributes>().isAlive = false;
                            }
                        }
                        Debug.Log($"Hit enemy {pickedEnemy.transform.gameObject.name}");
                    }
                }
            }
        


            // Logic to main player
            if (currentPlayer.GetComponent<PlayerAttributes>().hasGun &&
                Input.GetButtonDown("shoot"))
            {
                sound.Play();
            
                RaycastHit hit;
                //Debug.Log(Physics.Raycast(currentPlayer.transform.position, currentPlayer.transform.forward, out hit));
                if (Physics.Raycast(currentPlayer.transform.position, currentPlayer.transform.forward, out hit))
                {
                    target.transform.position = hit.point;
                    StartCoroutine(Shoot());
                    if (Enemy1.transform.gameObject.name == hit.transform.gameObject.name)
                    {
                        Enemy1.GetComponent<PlayerAttributes>().health -= minusHealth;
                        if (Enemy1.GetComponent<PlayerAttributes>().health <= 0)
                        {
                            Enemy1.GetComponent<NavMeshAgent>().enabled = false;
                            Enemy1.GetComponent<PlayerAttributes>().isAlive = false;
                        }
                        Debug.Log("Hit enemy 1");
                    }

                    if (Enemy2.transform.gameObject.name == hit.transform.gameObject.name)
                    {
                        Enemy2.GetComponent<PlayerAttributes>().health -= minusHealth;
                        if (Enemy2.GetComponent<PlayerAttributes>().health <= 0)
                        {
                            Enemy2.GetComponent<NavMeshAgent>().enabled = false;
                            Enemy2.GetComponent<PlayerAttributes>().isAlive = false;
                        }
                        Debug.Log("Hit enemy 2");
                    }

                }
            }
        }
        catch
        {

        }
    }
}
