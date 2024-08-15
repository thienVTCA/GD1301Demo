using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float moveSpeed = 100;
    [SerializeField]
    Transform gunTransform;
    [SerializeField]
    float timeShootingMax = 5;
    float timeShooting;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float maxHealth = 20;
    float currentHealth;
    AudioSource audioSource;
    [SerializeField]
    List<AudioClip> listAudioClips;// 0 - gun, 1 - hit , 2 - explossion
    [SerializeField]
    GameObject explosionarticlePrefab, hitParticlePrefab;
    void Start()
    {
        timeShooting = 0;
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("bullet"))
        {
            Instantiate(hitParticlePrefab, collision.transform.position, Quaternion.identity);
            audioSource.clip = listAudioClips[1];
            audioSource.Play();
            Destroy(collision.gameObject);
            currentHealth--;
            Debug.Log("enemy health " + currentHealth);
            if(currentHealth <= 0)
            {
                UIManager.uIManagerInstance.UpdateKillNumber();
                Instantiate(explosionarticlePrefab, collision.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("wall"))
        {
            UIManager.uIManagerInstance.UpdateKillNumber();
            if (collision.gameObject.tag.Equals("Player"))
            Instantiate(explosionarticlePrefab, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        if(timeShooting < timeShootingMax)
        {
            timeShooting += Time.deltaTime;
        }
        else
        {
            // shooting bullets
            //audioSource.clip = listAudioClips[0];
            //audioSource.Play();
            Instantiate(bulletPrefab, gunTransform.position, bulletPrefab.transform.rotation);
            timeShooting = 0;
        }
    }
}
