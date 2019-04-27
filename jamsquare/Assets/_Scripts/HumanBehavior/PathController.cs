using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public struct PathHuman
    {
    public Vector3 spawnPos;
    public Target startingTarget;
    public Human human;
            public PathHuman(Vector3 _pos, Target _targ, Human _hum)
            {
                spawnPos = _pos;
                startingTarget = _targ;
                human = _hum;
            }
    }
public class PathController : MonoBehaviour
{
    public List<PathHuman> humansData = new List<PathHuman>();

    public void Initialise()
    {
        foreach (var obj in GameObject.FindGameObjectsWithTag("Human"))
        {
            Human h = obj.GetComponent<Human>();
            if (h != null)
            {
                PathHuman pathHuman = new PathHuman(obj.transform.position , h.currentTarget, h);
                humansData.Add(pathHuman);
            }
        }
    }

    public void StarthHumans()
    {
        foreach (var item in humansData)
        {
            item.human.Initialise();
            item.human.enabled = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            Reset();
    }

    private void Reset()
    {
        foreach (var item in humansData)
        {
            item.human.gameObject.SetActive(true);
            item.human.gameObject.tag = "Human";
            item.human.transform.position = item.spawnPos;
            item.human.currentTarget = item.startingTarget;
            item.human.Initialise();

        }
    }



}
