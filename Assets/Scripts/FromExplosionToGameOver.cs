using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromExplosionToGameOver : MonoBehaviour
{

    private void OnDestroy() {
        FindObjectOfType<GameManager>().gameOver = true;
    }

}
