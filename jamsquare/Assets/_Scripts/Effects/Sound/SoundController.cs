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
    private List<AudioSource> screams;

    private List<AudioSource> allSounds;
    private  void Start()
    {
        allSounds = new List<AudioSource>();
        allSounds.AddRange(backgrounds);
        allSounds.AddRange(soundEffects);
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
