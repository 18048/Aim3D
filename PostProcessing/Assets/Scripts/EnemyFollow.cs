using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;
    public bool rotateCam = false;
    public bool mustFollow = false;

    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        SetTarget(target.position);
    }

    void SetTarget(Vector3 Target)
    {
        if (mustFollow) {
        agent.SetDestination(Target);
        }
    }

    // Update is called once per frame
    void Update()
    {

        SetTarget(target.position);
        if (agent.remainingDistance <= agent.stoppingDistance && agent.hasPath)
        {
            rotateCam = true;
        }
    }
}
