using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAnimManager : MonoBehaviour {

    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        switch(tag) {
            case "Scale_1":
                anim.SetBool("Normal", true);
                anim.SetBool("Reverse", false);
                break;
            case "Scale_2":
                anim.SetBool("Normal", false);
                anim.SetBool("Reverse", true);
                break;
        }
    }

}
