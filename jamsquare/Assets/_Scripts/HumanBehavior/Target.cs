using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public Target previousTarget;
    public Target nextTarget;
    public float range;

    public bool isStartTarget;
    public bool isEndTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (!isEndTarget && nextTarget != null)
        Gizmos.DrawLine(transform.position, nextTarget.transform.position);

        Gizmos.DrawSphere(transform.position, 0.5f);

        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void OnGetToTarget()
    {

    }
    public Target GetNextTarget()
    {
        return nextTarget;
    }
    public Target GetPreviousTarget()
    {
        return previousTarget;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
