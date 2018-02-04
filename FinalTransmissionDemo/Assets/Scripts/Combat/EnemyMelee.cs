using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour {

    public GameObject ObjectToMoveTo;
    private Mover mover;
    bool canMove = true;
    public Transform target;
    public float range;
    float distance;
    public int health = 100;

    void Start()
    {
        mover = GetComponent<Mover>();
    }

    void Update()
    {

        distance = Vector3.Distance(transform.position, target.position);

        if (distance < range)
        {
            if (canMove)
                mover.MoveTo(ObjectToMoveTo);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Survivor")
        {
            mover.Stop();
            canMove = false;
            health = health - (Random.Range(12, 18));
        }
        else if (other.gameObject.tag == "Node")
        {
            var node = other.gameObject.GetComponent<PathNode>();

            if (node.NextNode != null)
            {
                ObjectToMoveTo = node.NextNode.gameObject;
            }
            else
                canMove = false;
        }

        if (other.gameObject.tag == "Bullet")
        {
            health = health - 50;
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Survivor")
        {
            canMove = true;
        }
    }
}
