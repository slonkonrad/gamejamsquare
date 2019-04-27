using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCollector : MonoBehaviour
{
    [SerializeField] private List<GameObject> listOfAllHumans = new List<GameObject>();
    public Rigidbody[] rb;

    private int value;
    public void DeleteHumans()
    {
        foreach (var val in rb)
        {
            val.AddRelativeForce(Vector3.up * 0.0001f);
            val.gameObject.transform.parent = null;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        DeleteHumans();
    }
}
