using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private new Camera camera;
    private RaycastHit hit;
    public NavMeshAgent agent;

    public float rotateSpeedMovement = 0.1f;
    public float rotateVelocity;

    private HeroCombat heroCombatScript;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        heroCombatScript = GetComponent<HeroCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if(heroCombatScript.targetedEnemy != null)
        {
            if(heroCombatScript.targetedEnemy.GetComponent<HeroCombat>() != null)
            {
                if (heroCombatScript.targetedEnemy.GetComponent<HeroCombat>().isHeroAlive)
                {
                    heroCombatScript.targetedEnemy = null;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Floor")
                {
                    agent.SetDestination(hit.point);
                    heroCombatScript.targetedEnemy = null;
                    agent.stoppingDistance = 0;

                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.localEulerAngles.y,
                        rotationToLookAt.eulerAngles.y,
                        ref rotateVelocity,
                        rotateSpeedMovement * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);
                }
            }
        }

    }
}
