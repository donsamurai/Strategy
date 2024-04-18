using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AutoCarCreate : MonoBehaviour
{   

    public GameObject car;
    public float time = 5f;
    [NonSerialized] 
    public bool isEnemy = false;
    
    private void Start() {
        StartCoroutine(SpawnCar());
    }
    internal IEnumerator SpawnCar(){
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(time);
            Vector3 pos = new Vector3(
                transform.GetChild(0).position.x + UnityEngine.Random.Range(5f,15f),
                transform.GetChild(0).position.y,
                transform.GetChild(0).position.z + UnityEngine.Random.Range(5f,15f)
            );

            GameObject spawn = Instantiate(car, pos, Quaternion.identity);
            if(isEnemy)
                spawn.tag = "Enemy";

        }
    }
}
