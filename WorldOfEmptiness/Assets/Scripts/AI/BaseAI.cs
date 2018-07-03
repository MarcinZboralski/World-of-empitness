using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseAI : MonoBehaviour,AIAniamtor
{
    public AISettings AISettings;

    protected NavMeshAgent Agent;

    private float VievSphereSize;
    private float distanceToTarget;


    public float DistanceToTarget
    {
        get { return distanceToTarget; }
    }

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        AISettings.Init(Agent);
        Init();
    }

    public virtual void Init()
    {
        Agent.height = AISettings.Height;
        Agent.radius = AISettings.Radius;
        Agent.stoppingDistance = AISettings.StopDistance;
    }

    private void Update()
    {
        Move(AISettings.Target.position);
    }

    protected void Move(Vector3 Target)
    {
        if(NavMeshGeneratorAdapter.isDone != true)return; 


        distanceToTarget = Vector3.Distance(Target, transform.position);

        if (distanceToTarget >= AISettings.StopDistance)
        {
            Agent.SetDestination(Target);
        }

    }

    private void OnDrawGizmos()
    {

       // Gizmos.color = new Color(0f, 0.05f, 1f);
       // Gizmos.DrawWireSphere(transform.position,VievSphereSize);
    }

    public void SetAnimatror(bool walk, bool attack, bool death, bool hit)
    {
        
    }

    public void ResetAnimator()
    {
        
    }
}
