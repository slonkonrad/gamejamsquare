using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> particleGOs;

    public GameObject FindParticleGameObject(string name)
    {
        return particleGOs.FirstOrDefault(x => x.name == name);
    }

    public void FindParticleGameObjectAndInstiatateItOnTransform(string name, Vector3 position, Quaternion rotation)
    {
        GameObject newParticle = particleGOs.FirstOrDefault(x => x.name == name);
        if(!newParticle)
            return;
        GameObject newObject = Instantiate(newParticle, position, rotation);
        newObject.AddComponent<CFX_AutoDestructShuriken>();
    }
}
