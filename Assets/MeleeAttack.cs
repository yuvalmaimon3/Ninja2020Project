using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public AudioSource Axevoice;
    private bool isAttack = false;
    private Animator enemyAnimator;
    private FlipEnemy moveAndFlipEnemy;
    private EnemyHealth enemyHealth;
    private BoxCollider Sensor;
    // Start is called before the first frame update
    void Start()
    {
        Sensor = GetComponent<BoxCollider>();
        //   Sounds = GetComponent<AudioSource>();
        enemyAnimator = transform.parent.GetComponent<Animator>();
        moveAndFlipEnemy = transform.parent.GetComponent<FlipEnemy>();
        enemyHealth = transform.parent.GetComponent<EnemyHealth>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator Attacking()
    {

        isAttack = true;
        enemyAnimator.SetBool("Move", false);
        Axevoice.Play();
        yield return new WaitForSeconds(0.1f);
        enemyAnimator.SetTrigger("Attack");
        yield return new WaitForSeconds(1.4f);


        isAttack = false;

    } 
    private void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player")
            if (enemyHealth.aLive)
                if (player.GetComponent<Health>().isAlive) // check if the player a live because else its dont detect the object get out from trigger.
                {
                    moveAndFlipEnemy.ifAttack = true;
                    if (!isAttack)
                    {
                        StartCoroutine(Attacking());
                    }
                }
                else
                {
                    Sensor.enabled = false;
                    OnTriggerExit(player);
                }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            if (enemyHealth.aLive)
            {
                moveAndFlipEnemy.ifAttack = false;
                enemyAnimator.SetBool("Move", true);
            }
    }
}
