using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2;
    public Transform gunTransform;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(IEDestroy());
    }

    IEnumerator IEDestroy()
    {
        Debug.Log(gameObject.tag);
        yield return new WaitForSeconds(2);
        Debug.Log("hahaha");
        yield return new WaitForSeconds(2);
        Debug.Log("Destroy");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");
        var move = new Vector3(h,0,v);
        transform.Translate(move * moveSpeed * Time.deltaTime);
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab,gunTransform.position,bulletPrefab.transform.rotation);
        }
    }
}
