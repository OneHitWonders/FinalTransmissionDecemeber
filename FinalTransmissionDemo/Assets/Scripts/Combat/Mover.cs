using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Mover : MonoBehaviour {

    private NavMeshAgent agent;


	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}

    public void MoveTo(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public void MoveTo(GameObject target)
    {
        MoveTo(target.transform.position);
    }

    public void Stop()
    {
        agent.isStopped = true;
    }
	
}
