using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2;
    public Transform gunTransform;
    public GameObject bulletPrefab;
    [SerializeField]
    float maxHealth = 20;
    float currentHealth;
    [SerializeField]
    float timeShootingMax = 5;
    float timeShooting;
    AudioSource audioSource;
    [SerializeField]
    List<AudioClip> listAudioClips;// 0 - gun, 1 - hit , 2 - explossion
    // Start is called before the first frame update
    [SerializeField]
    GameObject explosionarticlePrefab, hitParticlePrefab;
    void Start()
    {
        timeShooting = 0;
        currentHealth = maxHealth;
        UIManager.uIManagerInstance.UpdateHealthSlider(1);
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bulletEnemy"))
        {
            Instantiate(hitParticlePrefab, collision.transform.position, Quaternion.identity);
            audioSource.clip = listAudioClips[1];
            audioSource.Play();
            Destroy(collision.gameObject);
            currentHealth--;
            UIManager.uIManagerInstance.UpdateHealthSlider(currentHealth / maxHealth);
            Debug.Log("player health " + currentHealth);
            if (currentHealth <= 0)
            {
                UIManager.uIManagerInstance.GameOver();
                Instantiate(explosionarticlePrefab, collision.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag.Equals("enemy"))
        {
            UIManager.uIManagerInstance.GameOver();
            Instantiate(explosionarticlePrefab, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");
        var move = new Vector3(h,0,v);
        transform.Translate(move * moveSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, gunTransform.position, bulletPrefab.transform.rotation);
        }
        //if (timeShooting < timeShootingMax)
        //{
        //    timeShooting += Time.deltaTime;
        //}
        //else
        //{
        //    // shooting bullets
        //    audioSource.clip = listAudioClips[0];
        //    audioSource.Play();
        //    Instantiate(bulletPrefab, gunTransform.position, bulletPrefab.transform.rotation);
        //    timeShooting = 0;
        //}
    }
}
