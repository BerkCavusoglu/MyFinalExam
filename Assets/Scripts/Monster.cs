using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject leavesParticlePrefab;
    public GameObject fireParticlePrefab;
    [SerializeField] private AudioSource patlamaSes;

    public int hitsToDestroy = 30;
    private int hitCount = 0;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ActivateHit2Particle(transform.position);
        }
        else if (collision.gameObject.tag == "Taþ")
        {
            hitCount++;

            if (hitCount >= hitsToDestroy)
            {
                ActivateLeavesParticle(transform.position);
                patlamaSes.Play(); // Yalnýzca monster öldüðünde sesi çal
                Destroy(gameObject);
            }
        }
    }

    void ActivateLeavesParticle(Vector2 position)
    {
        GameObject leavesParticles = Instantiate(leavesParticlePrefab, position, Quaternion.identity);
        leavesParticles.SetActive(true);
        Destroy(leavesParticles, 2f);
    }

    void ActivateHit2Particle(Vector2 position)
    {
        GameObject fireParticles = Instantiate(fireParticlePrefab, position, Quaternion.identity);
        fireParticles.SetActive(true);
        Destroy(fireParticles, 2f);
    }
}

