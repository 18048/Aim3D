using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;
    public bool rotateCam = false;

    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        SetTarget(target.position);
    }

    void SetTarget(Vector3 Target)
    {
        agent.SetDestination(Target);
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget(target.position);
        //Debug.Log("remainingDistance = " + agent.remainingDistance);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            rotateCam = true;
        }
    }
}
