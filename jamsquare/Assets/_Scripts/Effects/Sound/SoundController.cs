using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoundController : MonoBehaviour
{   
    [SerializeField]
    private List<AudioSource> backgrounds;

    [SerializeField]
    private List<AudioSource> soundEffects;

    [SerializeField]
    private AudioSource engineSound;

    [SerializeField]
    private List<AudioSource> screams;

    private List<AudioSource> allSounds;

    private  void Start()
    {
        allSounds = new List<AudioSource>();
        allSounds.AddRange(backgrounds);
        allSounds.AddRange(soundEffects);
    }

    public void updateCarEngineSound(float velocityMagnitude)
    {
        float value = Mathf.Log10(Mathf.Abs(velocityMagnitude));
        if(value>=0)
        {
            engineSound.pitch = Mathf.Clamp(value, 0.4f, 1f);
            engineSound.volume = Mathf.Clamp(value, 0.5f, 1f);
            engineSound.spatialBlend = 0.5f - Mathf.Clamp(value, 0, 0.5f);
        }
        // else
        //     engineSound.pitch = Mathf.Clamp(value, -0.8f, -0.2f);
        //     //to ADD!!
    }

    public void playScream()
    {
        AudioSource chosenSound = screams[Random.Range(0, screams.Count)];
        if(chosenSound)
            chosenSound.Play();
    }
    public void playSound(string name)
    {
        AudioSource chosenSound = getSoundByName(name);
        if(chosenSound)
            chosenSound.Play();
    }

    public void stopSound(string name)
    {
        AudioSource chosenSound = getSoundByName(name);
        if(chosenSound)
            chosenSound.Stop();
    }

    private AudioSource getSoundByName(string name) 
    {
        return allSounds.FirstOrDefault(x => x.gameObject.name == name);
    }    
}
