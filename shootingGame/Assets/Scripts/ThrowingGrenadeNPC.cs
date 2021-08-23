using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThrowingGrenadeNPC : MonoBehaviour
{
    private bool isThrowen = false;
    public GameObject grenadePrefab;
    public GameObject currentPlayer;
    private AudioSource sound;

    public GameObject enemy1;
    public GameObject enemy2;

    int minusHealth = 20;
    // Start is called before the first frame update
    void Start()
    {
        sound = currentPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isThrowen && 
            currentPlayer.GetComponent<PlayerAttributes>().hasGrenade && 
            !currentPlayer.GetComponent<PlayerAttributes>().threwGrenade)
        {
            currentPlayer.GetComponent<PlayerAttributes>().threwGrenade = true;
            isThrowen = true;
            ThrowGgenade();
        }
    }

    void ThrowGgenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Vector3 direction = currentPlayer.transform.forward * 8;
        direction.y = 3;
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(direction, ForceMode.Impulse);
        StartCoroutine(Explode(grenade));
    }

    IEnumerator Explode(GameObject grenade)
    {
        if (currentPlayer.GetComponent<PlayerAttributes>().num == 0)
        {
            yield return new WaitForSeconds(2.5f);
            grenade.transform.GetChild(1).gameObject.SetActive(true);
            sound.Play();
            isThrowen = false;
            Collider[] objectsCollider = Physics.OverlapSphere(transform.position, 20);
            for (int i = 0; i < objectsCollider.Length; i++)
            {
                if (objectsCollider[i] != null)
                {
                    if (objectsCollider[i].transform.gameObject.name == enemy1.transform.gameObject.name)
                    {
                        enemy1.GetComponent<PlayerAttributes>().health -= minusHealth;
                        if (enemy1.GetComponent<PlayerAttributes>().health <= 0)
                        {
                            enemy1.GetComponent<NavMeshAgent>().enabled = false;
                            enemy1.GetComponent<PlayerAttributes>().isAlive = false;
                        }
                        Debug.Log("Hit npc grenade");
                    }
                    if (objectsCollider[i].transform.gameObject.name == enemy2.transform.gameObject.name)
                    {
                        enemy2.GetComponent<PlayerAttributes>().health -= minusHealth;
                        if (enemy2.GetComponent<PlayerAttributes>().health <= 0)
                        {
                            enemy2.GetComponent<NavMeshAgent>().enabled = false;
                            enemy2.GetComponent<PlayerAttributes>().isAlive = false;
                        }
                        Debug.Log("Hit npc grenade");
                    }
                    Rigidbody rbo = objectsCollider[i].GetComponent<Rigidbody>();
                    if (rbo != null)
                        rbo.AddExplosionForce(2500.0f, transform.position, 20);
                }
            }
            yield return new WaitForSeconds(0.5f);
            Destroy(grenade);
        }
        if (currentPlayer.GetComponent<PlayerAttributes>().num == 1)
        {
            yield return new WaitForSeconds(2.5f);
            grenade.transform.GetChild(1).gameObject.SetActive(true);
            sound.Play();
            isThrowen = false;
            Collider[] objectsCollider = Physics.OverlapSphere(transform.position, 20);
            for (int i = 0; i < objectsCollider.Length; i++)
            {
                if (objectsCollider[i] != null)
                {
                    if (objectsCollider[i].transform.gameObject.name == enemy1.transform.gameObject.name)
                    {
                        enemy1.GetComponent<PlayerAttributes>().health -= minusHealth;
                        if (enemy1.GetComponent<PlayerAttributes>().health <= 0)
                        {
                            enemy1.GetComponent<NavMeshAgent>().enabled = false;
                            enemy1.GetComponent<PlayerAttributes>().isAlive = false;
                        }
                        Debug.Log("Hit npc grenade");
                    }
                    if (objectsCollider[i].transform.gameObject.name == enemy2.transform.gameObject.name)
                    {
                        enemy2.GetComponent<PlayerAttributes>().health -= minusHealth;
                        if (enemy2.GetComponent<PlayerAttributes>().health <= 0)
                        {
                            enemy2.GetComponent<NavMeshAgent>().enabled = false;
                            enemy2.GetComponent<PlayerAttributes>().isAlive = false;
                        }
                        Debug.Log("Hit npc grenade");
                    }
                    Rigidbody rbo = objectsCollider[i].GetComponent<Rigidbody>();
                    if (rbo != null)
                        rbo.AddExplosionForce(2500.0f, transform.position, 20);
                }
            }
            yield return new WaitForSeconds(0.5f);
            Destroy(grenade);
        }
        if (currentPlayer.GetComponent<PlayerAttributes>().num == 2)
        {
            yield return new WaitForSeconds(2.5f);
            grenade.transform.GetChild(1).gameObject.SetActive(true);
            sound.Play();
            isThrowen = false;
            Collider[] objectsCollider = Physics.OverlapSphere(transform.position, 20);
            for (int i = 0; i < objectsCollider.Length; i++)
            {
                if (objectsCollider[i] != null)
                {
                    if (objectsCollider[i].transform.gameObject.name == enemy1.transform.gameObject.name)
                    {
                        enemy1.GetComponent<PlayerAttributes>().health -= minusHealth;
                        if (enemy1.GetComponent<PlayerAttributes>().health <= 0)
                        {
                            enemy1.GetComponent<NavMeshAgent>().enabled = false;
                            enemy1.GetComponent<PlayerAttributes>().isAlive = false;
                        }
                        Debug.Log("Hit npc grenade");
                    }
                    if (objectsCollider[i].transform.gameObject.name == enemy2.transform.gameObject.name)
                    {
                        enemy2.GetComponent<PlayerAttributes>().health -= minusHealth;
                        if (enemy2.GetComponent<PlayerAttributes>().health <= 0)
                        {
                            enemy2.GetComponent<NavMeshAgent>().enabled = false;
                            enemy2.GetComponent<PlayerAttributes>().isAlive = false;
                        }
                        Debug.Log("Hit npc grenade");
                    }
                    Rigidbody rbo = objectsCollider[i].GetComponent<Rigidbody>();
                    if (rbo != null)
                        rbo.AddExplosionForce(2500.0f, transform.position, 20);
                }
            }
            yield return new WaitForSeconds(0.5f);
            Destroy(grenade);
        }
    }
}
