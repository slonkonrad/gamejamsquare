using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zmieniator : MonoBehaviour
{

    public Target[] targets;
    [ContextMenu("link")]
    void link()
    {
        for (int i = 1; i < targets.Length-1; i++)
        {
            targets[i].nextTarget = targets[i + 1];
            targets[i].previousTarget = targets[i - 1];
            targets[i].waitTime = 0;
            targets[i].isEndTarget = targets[i].isStartTarget = false;
        }
    }

    public GameObject[] prefabs;
    public GameObject[] toReplace;

    [ContextMenu("replace")]
    void replace()
    {
        for (int i = 1; i < toReplace.Length - 1; i++)
        {
            Transform transformToReplace = toReplace[i].transform;
            Target targetToReplace = toReplace[i].GetComponentInParent<Target>();

            int number = Random.Range(1, prefabs.Length-1);

            GameObject newObj = Instantiate(prefabs[number], transformToReplace.parent);
            newObj.transform.position = transformToReplace.position;
            newObj.GetComponent<Human>().currentTarget = targetToReplace;

            DestroyImmediate(toReplace[i]);


        }
    }


}
