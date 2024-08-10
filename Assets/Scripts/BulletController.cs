using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 2;
    [SerializeField]
    float timeDestroy = 3;
    [SerializeField]
    bool isEnemy = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IEDestroy());
    }
    IEnumerator IEDestroy()
    {
        yield return new WaitForSeconds(timeDestroy);
        Debug.Log("Destroy");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnemy)
        {
            transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * bulletSpeed * Time.deltaTime);
        }
    }
}
