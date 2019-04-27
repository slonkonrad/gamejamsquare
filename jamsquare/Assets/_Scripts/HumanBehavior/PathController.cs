using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public List<Human> pathHumans;
    void Start()
    {

        foreach (var human in pathHumans)
        {
            human.Initialise();
            human.enabled = false;
        }

        StartCoroutine(ReleseHumans());
    }


    IEnumerator ReleseHumans()
    {
        foreach (var human in pathHumans)
        {
            yield return new WaitForSeconds (human.startRandomValue);
            human.enabled = true;

        }
    }
}
