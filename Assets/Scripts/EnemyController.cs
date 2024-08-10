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
    void Start()
    {
        timeShooting = 0;
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("bullet"))
        {
            currentHealth--;
            Debug.Log("enemy health " + currentHealth);
            if(currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag.Equals("player"))
        {
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
            Instantiate(bulletPrefab, gunTransform.position, bulletPrefab.transform.rotation);
            timeShooting = 0;
        }
    }
}
