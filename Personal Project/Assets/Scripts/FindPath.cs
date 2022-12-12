using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPath : MonoBehaviour
{

    public float speed;
    public GameObject minion;
    public Vector3 target = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.Find("");
    }

    // Update is called once per frame
    void Update()
    {
        minion.transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }
}