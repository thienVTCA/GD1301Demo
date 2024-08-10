using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWingRotate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float rotateSpeed = 1000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left * rotateSpeed * Time.deltaTime);
    }
}
