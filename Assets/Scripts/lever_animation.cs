using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever_animation : MonoBehaviour
{   
    public Animator anim;
    public bool time_over = false;
    public float timer;
    public Player player;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void lever_over(){
        timer += Time.deltaTime;
        if(timer>=5f) {time_over = true;}
    }

    void Update()
    {
        if(player.reached_lever){
            anim.Play("lever_rotate");
            lever_over();
            if(time_over){
                player.DestroyObject();
            }
        }
    }
}
