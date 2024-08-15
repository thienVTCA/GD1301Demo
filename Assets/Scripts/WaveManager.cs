using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    List<Transform> listPosTransforms;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < listPosTransforms.Count; i++)
        {
            Instantiate(enemyPrefab, listPosTransforms[i].position, enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
