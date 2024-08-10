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
    // Start is called before the first frame update
    void Start()
    {
        timeShooting = 0;
        currentHealth = maxHealth;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bulletEnemy"))
        {
            currentHealth--;
            Debug.Log("player health " + currentHealth);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag.Equals("enemy"))
        {
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
        //if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(bulletPrefab,gunTransform.position,bulletPrefab.transform.rotation);
        //}
        if (timeShooting < timeShootingMax)
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
