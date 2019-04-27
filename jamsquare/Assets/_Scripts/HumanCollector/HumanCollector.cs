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
        var val = Random.Range(0, rb.Length);
        listOfAllHumans[val].GetComponent<Outline>().enabled = false;
        rb[val].constraints = RigidbodyConstraints.None;
        rb[val].AddForce(Vector3.up * 0.00001f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag != "Human" && collision.collider.tag != "road")
            DeleteHumans();
    }
}
