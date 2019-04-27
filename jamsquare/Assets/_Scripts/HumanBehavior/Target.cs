using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public enum StateType
    {
        GoToTarget,

    }
    public StateType myStateType;
    public Target previousTarget;
    public Target nextTarget;
    public float range;

    public bool isStartTarget;
    public bool isEndTarget;


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
        switch (myStateType)
        {
            case StateType.GoToTarget:
                Debug.Log("elo0");
        h.SetGoToTargetState(nextTarget);
                break;
        }
    }
    public Target GetNextTarget(Human h)
    {
        OnTargetGet(h);
        Debug.Log("debug" + this.name);
        return nextTarget;
    }
    public Target GetPreviousTarget()
    {
        return previousTarget;
    }
}
