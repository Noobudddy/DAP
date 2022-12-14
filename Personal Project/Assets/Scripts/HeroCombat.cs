using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCombat : MonoBehaviour
{
    public enum HeroAttackType { Ranged };
    public HeroAttackType heroAttackType;

    public GameObject targetedEnemy;
    public float attackRange;
    public float rotateSpeedForAttack;

    private PlayerController moveScript;

    public bool basicAtkIdle = false;
    public bool isHeroAlive;
    public bool performMeleeAttack = true;

    [Header("Ranged Varialbes")]
    public bool performRangedAttack = true;
    public GameObject projPrefab;
    public Transform projSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetedEnemy != null)
        {
            if (Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) > attackRange)
            {
                moveScript.agent.SetDestination(targetedEnemy.transform.position);
                moveScript.agent.stoppingDistance = attackRange;
            }
            else
            {
                if (heroAttackType == HeroAttackType.Ranged)
                {
                    //ROTATION
                    Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                        rotationToLookAt.eulerAngles.y,
                        ref moveScript.rotateVelocity,
                        rotateSpeedForAttack * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);

                    moveScript.agent.SetDestination(transform.position);

                    if (performRangedAttack)
                    {
                        Debug.Log("Attack The Minion");

                        //Start Coroutine To Attack
                        //StartCoroutine(RangedAttackInterval());
                    }
                }
            }
        }
    }
}