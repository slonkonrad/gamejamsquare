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
        StartCoroutine(particleLifeCoroutine(newParticle, transform));
    }

    private IEnumerator particleLifeCoroutine(ParticleSystem particle, Transform transform)
    {
        GameObject particleGameObject = Instantiate(particle.gameObject, transform);
        while(particle.IsAlive())
        {
            yield return new WaitForSeconds(0.5f);
        }
        Destroy(particleGameObject);
        yield return null;
    }
}
