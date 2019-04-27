using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public enum StateType
    {
        GoToTarget,
        Wait,

    }
    public StateType myStateType;
    public Target previousTarget;
    public Target nextTarget;
    public float range;

    public float waitTime;

    public bool isStartTarget;
    public bool isEndTarget;

    private void Start()
    {
        GetComponent<SphereCollider>().radius = range;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (!isEndTarget && nextTarget != null)
        Gizmos.DrawLine(transform.position, nextTarget.transform.position);

        Gizmos.DrawSphere(transform.position, 0.5f);

        Gizmos.DrawWireSphere(transform.position, range);
    }
    public void OnTargetGet(Human h)
    {
        if (!isEndTarget)
        {
            switch (myStateType)
            {
                case StateType.GoToTarget:
                    Debug.Log("elo0");
                    h.SetGoToTargetState(nextTarget,waitTime);
                    break;
                case StateType.Wait:
                    Debug.Log("elo1");
                    h.SetWaitState(nextTarget,waitTime);
                    break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Human")
        {
            other.GetComponent<Human>().currentState.ChangeTarget();
        }
    }
    public Target GetNextTarget(Human h)
    {
        OnTargetGet(h);
        return nextTarget;
    }
    public Target GetPreviousTarget()
    {
        return previousTarget;
    }
}
