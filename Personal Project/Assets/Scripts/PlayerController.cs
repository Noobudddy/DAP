using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera camera;
    private RaycastHit hit;
    public NavMeshAgent agent;
    private string groundTag = "Ground";

    public float rotateSpeedMovement = 0.1f;
    float rotateVelocity;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag(groundTag))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }

    }
}

/*Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
    rotationToLookAt.eulerAngles.y,
    ref rotateVelocity,
    rotateSpeedMovement * (Time.deltaTime * 5));

transform.eulerAngles = new Vector3(0, rotationY, 0);*/