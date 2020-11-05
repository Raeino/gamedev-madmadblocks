using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWavesController : MonoBehaviour
{

    public GameObject[] waves;
    public float speed;

    private bool isWaving = false;
    private bool canWave = false;

    private void Start() {
        StartCoroutine(SetCanWave());
    }

    private void Update() {
        
        if(canWave) {
            isWaving = true;
            for(int i = 0; i < waves.Length; i++) {
                if (waves[i].CompareTag("SineHorizontal")) {
                    waves[i].transform.position = new Vector3(waves[i].transform.position.x - speed * Time.deltaTime,
                        waves[i].transform.position.y, waves[i].transform.position.z);
                    if(waves[i].transform.position.x <= -114 || waves[i].transform.position.x >= 117) {
                        isWaving = false;
                        //bug fix
                        waves[i].transform.position = new Vector3(waves[i+1].transform.position.x,
                        waves[i].transform.position.y, waves[i].transform.position.z);
                        speed *= -1;
                    }
                } else if (waves[i].CompareTag("SineVertical")) {
                    waves[i].transform.position = new Vector3(waves[i].transform.position.x,
                        waves[i].transform.position.y - speed * Time.deltaTime, waves[i].transform.position.z);
                    if (waves[i].transform.position.y <= -114 || waves[i].transform.position.y >= 118) {
                        //bug fix
                        waves[i].transform.position = new Vector3(waves[i].transform.position.x,
                        waves[i+1].transform.position.y, waves[i].transform.position.z);
                        isWaving = false;
                    }
                }

            }

        }
    }

    //dead code
    private IEnumerator SetCanWave() {
        while(true) {
            yield return new WaitUntil(() => isWaving == false);
            canWave = false;
            yield return new WaitForSeconds(0);
            canWave = true;
        }

    }
}
