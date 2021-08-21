using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingGrenadeNPC : MonoBehaviour
{
    private bool isThrowen = false;
    public GameObject player;
    public GameObject grenadePrefab;
    public GameObject currentPlayer;
    private AudioSource sound;

    public GameObject enemy1;
    public GameObject enemy2;
    // Start is called before the first frame update
    void Start()
    {
        sound = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayer.GetComponent<PlayerAttributes>().hasGrenade)
        {
            currentPlayer.GetComponent<PlayerAttributes>().hasGrenade = false;
            isThrowen = true;
            ThrowGgenade();
        }
    }

    void ThrowGgenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Vector3 direction = player.transform.forward * 8;
        direction.y = 3;
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(direction, ForceMode.Impulse);
        StartCoroutine(Explode(grenade));
    }

    IEnumerator Explode(GameObject grenade)
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
                Rigidbody rbo = objectsCollider[i].GetComponent<Rigidbody>();
                if (rbo != null)
                    rbo.AddExplosionForce(2500.0f, transform.position, 20);
            }
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(grenade);
    }
}
