using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(FindObjectOfType<GameManager>().section == GameManager.Section.Pause) {
            anim.SetBool("isPausing", true);
            anim.SetBool("isResuming", false);
        }

        if (FindObjectOfType<GameManager>().section == GameManager.Section.Game) {
            anim.SetBool("isResuming", true);
            anim.SetBool("isPausing", false);
        }
    }
}
