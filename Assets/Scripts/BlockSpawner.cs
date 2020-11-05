using System.Collections;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;
    public float spawnX;

    private GameObject shadow;
    private GameObject realBlock;
    public float timeBtwSpawns;

    public int maxProbBlockOnScreen;

    public float[] scoreCheckPoint;
    private bool[] checkedCheckPoint;

    public bool[] canInstantiate;
    private readonly int lineBlock = 8;

    public void Start()
    {
        StartCoroutine(SpawnBlock());
        checkedCheckPoint = new bool[scoreCheckPoint.Length];
        canInstantiate = new bool[lineBlock];
        for(int i = 0; i < scoreCheckPoint.Length - 1; i++) {
            checkedCheckPoint[i] = false;
        }
    }

    public IEnumerator SpawnBlock() {
        while(true) {
            yield return new WaitForSeconds(0f);
            bool emptyLine = true;
            float score = FindObjectOfType<ScoreUpdate>().score;
            for (int i = 0; i < lineBlock; i++) {
                if (Random.Range(0, maxProbBlockOnScreen) == 0) {
                    canInstantiate[i] = true;
                    emptyLine = false;
                } else
                    canInstantiate[i] = false;
            }

            if(!emptyLine) {
                yield return new WaitForSeconds(timeBtwSpawns);
                for (int i = 0; i < lineBlock; i++) {
                    if(canInstantiate[i]) {
                        const float spawnY = 3.5f;
                        BlockSpawn(spawnY, i);
                        ShadowSpawn();
                    }
                }
            }

            UpdateFrequency(score);
        }   
    }

    private void BlockSpawn(float spawnY, int i) {
        realBlock = Instantiate(block, new Vector3(spawnX, spawnY - i, 0), new Quaternion(0, 0, 0, 0));
    }

    private void ShadowSpawn() {
        shadow = Instantiate(block, realBlock.transform);
        shadow.transform.position = new Vector3(realBlock.transform.position.x - 0.1f, realBlock.transform.position.y - 0.1f, 1);
        shadow.transform.localScale = realBlock.transform.localScale * 1.25f;
        shadow.GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.75f, 0.75f, 0.5f);
        shadow.tag = "Shadow";
    }

    private void UpdateFrequency(float score) {
        for(int i = 0; i < scoreCheckPoint.Length - 1; i++) {
            if(score >= scoreCheckPoint[i] && !checkedCheckPoint[i]) {
                maxProbBlockOnScreen--;
                checkedCheckPoint[i] = true;
                return;
            }
        }
    }
}