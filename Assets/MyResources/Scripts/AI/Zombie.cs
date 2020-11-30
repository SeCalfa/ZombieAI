using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : StateMachineBehaviour
{
    protected GameObject[] wayPoints;
    protected GameObject player;

    protected GameObject NPC;
    protected int currentWP;
    protected float rotationSpeed = 2.0f;
    protected float speed = 1.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        currentWP = 0;
        wayPoints = animator.GetComponent<Enemy>()._wayPoints;
        player = animator.GetComponent<Enemy>()._player;
    }

    protected void SetDistance(Animator animator)
    {
        animator.SetFloat("Distance", Vector3.Distance(player.transform.position, NPC.transform.position));
    }
}
