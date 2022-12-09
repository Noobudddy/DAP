using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindPath : MonoBehaviour
{

    public NavMeshAgent myAgent;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        myAgent.SetDestination(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
