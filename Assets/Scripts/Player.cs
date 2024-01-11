using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isTouchingKey = false;
    public AudioClip jumpSound;
    public AudioClip keyPickupSound;
    public AudioClip altin;
    public GameObject spikesParticlePrefab;
    public AudioSource audioSource;
    public Image keyImage;
    public GameObject tas;
    public Transform atesNoktasi;
    public float atisHizi;
    public float ziplamaGucu = 5f;
    public float Trambolin = 5000f;
    public GameObject hit2ParticlePrefab;
    public Text skor;

    private bool isGrounded = false;
    private bool canJump = false;
    private GameObject currentTeleporter;

    public int health = 5;
    public Text healthText;
    public Image[] healthImages;

    private int puan = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("KarakterHizi"))
        {
            moveSpeed = PlayerPrefs.GetFloat("KarakterHizi");
        }

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = jumpSound;

        UpdateHealthText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;     
            }
        }
        if (health > 0)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
            {
                Jump();
            }

            CheckKey();
            if (Input.GetKeyDown(KeyCode.F))
            {
                Shoot();
            }
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Jump()
    {
        if (gameObject.CompareTag("Trambolin"))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * Trambolin, ForceMode2D.Impulse);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, ziplamaGucu);
        }

        if (jumpSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }

        canJump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Anahtar")
        {
            isTouchingKey = true;
            PickUpKey(collision.gameObject);
        }
        else if (collision.tag == "Enemy")
        {
            ActivateHit2Particle(transform.position);
            TakeDamage(1);
        }
        else if (collision.tag == "Teleporter")
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Anahtar")
        {
            isTouchingKey = false;
        }
        else if (collision.tag == "Teleporter")
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }

    void PickUpKey(GameObject key)
    {
        if (keyPickupSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(keyPickupSound);
        }

        key.SetActive(false);
        isTouchingKey = false;

        if (keyImage != null)
        {
            keyImage.gameObject.SetActive(true);
        }
    }

    void CheckKey()
    {
        if (isTouchingKey)
        {
            GameObject keyObject = GameObject.FindGameObjectWithTag("Anahtar");

            if (keyObject != null)
            {
                keyObject.SetActive(false);
                isTouchingKey = false;

                if (keyPickupSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(keyPickupSound);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Spikes")
        {
            ActivateSpikesParticle(collision.gameObject);
            isGrounded = true;
            canJump = true;
            TakeDamage(1);
        }
        else if (collision.collider.tag == "Ground" || collision.collider.tag == "Kaya")
        {
            isGrounded = true;
            canJump = true;
        }
        else if (collision.collider.tag == "Enemy")
        {
            TakeDamage(1);
        }
        else if (collision.collider.tag == "Monster")
        {
            TakeDamage(4);
        }
        else if (collision.collider.tag == "Fan")
        {
            TakeDamage(2);
        }
        else if (collision.collider.tag == "Trambolin")
        {
            Jump();
        }
        else if (collision.collider.tag == "altin")
        {
            collision.collider.gameObject.SetActive(false);
            audioSource.PlayOneShot(altin);
            Skorayar();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Kaya" || collision.collider.tag == "Enemy")
        {
            isGrounded = false;
        }
    }

    void ActivateSpikesParticle(GameObject spikesObject)
    {
        GameObject particleSystem = Instantiate(spikesParticlePrefab, spikesObject.transform.position, Quaternion.identity);
        particleSystem.SetActive(true);
        Destroy(particleSystem, 2f);
    }

    public void Shoot()
    {
        GameObject mermi = Instantiate(tas, atesNoktasi.position, Quaternion.identity);
        float hizX = transform.localScale.x > 0 ? atisHizi : -atisHizi;
        mermi.GetComponent<Rigidbody2D>().velocity = new Vector2(hizX, 0);
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthText();

        if (health <= 0)
        {
            Time.timeScale = 0f;
        }
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Sağlık: " + health;
        }

        if (healthImages != null)
        {
            for (int i = 0; i < healthImages.Length; i++)
            {
                if (healthImages[i] != null)
                {
                    if (i < health)
                    {
                        healthImages[i].enabled = true;
                    }
                    else
                    {
                        healthImages[i].enabled = false;
                    }
                }
                else
                {
                    Debug.LogError("healthImages[" + i + "] is null. Make sure healthImages array is properly assigned in the inspector.");
                }
            }
        }
        else
        {
            Debug.LogError("healthImages array is null. Make sure it is properly assigned in the inspector.");
        }
    }

    void Skorayar()
    {
        puan += 5;
        skor.text = "SKOR:" + puan.ToString();
    }

    void ActivateHit2Particle(Vector2 position)
    {
        GameObject hit2Particles = Instantiate(hit2ParticlePrefab, position, Quaternion.identity);
        hit2Particles.SetActive(true);
        Destroy(hit2Particles, 2f);
    }
}
