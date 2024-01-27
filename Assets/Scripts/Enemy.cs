
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject leavesParticlePrefab;
    public GameObject hit2ParticlePrefab; 
    [SerializeField] private AudioSource patlamaSes;

    public int hitsToDestroy = 3;
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
            // Create hit2 effect when Player Enemy imagine hits
            ActivateHit2Particle(transform.position);
        }
        else if (collision.gameObject.tag == "Taþ")
        {
            hitCount++;

            if (hitCount >= hitsToDestroy)
            {
                ActivateLeavesParticle(transform.position);
                Destroy(gameObject);
                patlamaSes.Play();
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
        GameObject hit2Particles = Instantiate(hit2ParticlePrefab, position, Quaternion.identity);
        hit2Particles.SetActive(true);
        Destroy(hit2Particles, 2f);
    }
}
