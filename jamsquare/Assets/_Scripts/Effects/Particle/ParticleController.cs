using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private List<ParticleSystem> particles;

    public void FindAndInstantiateParticleAtTransform(string name, Transform transform) 
    {
        ParticleSystem newParticle = particles.FirstOrDefault(x => x.gameObject.name == name);
        if(!newParticle)
            return;
        StartCoroutine(particleLifeCoroutine(newParticle, transform.position, transform.rotation));
    }

    public void FindAndInstantiateParticleAtTransform(string name, Vector3 pos, Quaternion rot)
    {
        ParticleSystem newParticle = particles.FirstOrDefault(x => x.gameObject.name == name);
        if (!newParticle)
            return;
        StartCoroutine(particleLifeCoroutine(newParticle, pos, rot));
    }

    private IEnumerator particleLifeCoroutine(ParticleSystem particle, Vector3 pos, Quaternion rot)
    {
        GameObject particleGameObject = Instantiate(particle.gameObject, pos, rot);
        while(particle.IsAlive())
        {
            yield return new WaitForSeconds(0.5f);
        }
        Destroy(particleGameObject);
        yield return null;
    }
}
