using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Human : MonoBehaviour
{
    public Rigidbody rb;
    public Transform model;
    public Target currentTarget;
    public Animator animator;
    public Transform busParent;
    [SerializeField]
    public float speed = 2;


    public bool hasAnimation = false;
    [SerializeField]
    public float maxVelocity;
    [SerializeField]
    public float acceleration;

    public BaseHState currentState;

    private IScoreListener scoreListener;

    public void Initialise(IScoreListener scoreListener)
    {
        rb = GetComponent<Rigidbody>();
        currentTarget.GetComponentInParent<Target>();
        currentState = new GoToTargetState();
        currentState.Initialise(this,currentTarget);

        this.scoreListener = scoreListener;
    }

    void FixedUpdate()
    {
        CustomFixedUpdate();
    }
    private void Update()
    {
        CustomUpdate();
    }
    void CustomFixedUpdate()
    {
        if(currentState!=null)
            currentState.FixedUpdateState();
    }
    void CustomUpdate()
    {
        if(currentState!=null)
            currentState.UpdateState();
    }
    public void PlayParticle()
    {

    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == Keys.Tags.BUS)
        {
            if (this.transform.parent != busParent && busParent!=null)
                return;
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            GameController.Instance.ParticleController.FindParticleGameObjectAndInstiatateItOnTransform(Keys.Particles.HIT, pos, rot);
            GameController.Instance.ParticleController.FindParticleGameObjectAndInstiatateItOnTransform(Keys.Particles.BLOOD, pos, rot);
            GameController.Instance.SoundController.playScream();
            SetHittedState(currentTarget,1);

            scoreListener.NpcKilled(other.gameObject.GetComponentInParent<PlayerCar>().PlayerId);
        }
    }

    public void SetGoToTargetState(Target target, float waitTime)
    {
        if (currentState == null)
            return;
        currentState.Deinitialise();
        currentState = new GoToTargetState();
        currentState.myWaitTime = waitTime;
        currentState.Initialise(this, target);
        
    }
    public void SetWaitState(Target target, float waitTime)
    {
        if (currentState == null)
            return;
        currentState.Deinitialise();
        currentState = new WaitState();
        currentState.myWaitTime = waitTime;
        currentState.Initialise(this, target);
    }
    public void SetHittedState(Target target, float waitTime)
    {
        if (currentState == null)
            return;
        currentState.Deinitialise();
        currentState = new HittedState();
        currentState.myWaitTime = waitTime;
        currentState.Initialise(this, target);



    }

}
