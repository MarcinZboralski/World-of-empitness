using System;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class BaseAI : MonoBehaviour,AIAniamtor
    {
        public AISettings AISettings;
        public AIStatistic AIStatistic;

        protected NavMeshAgent Agent;

        private float distanceToTarget;
        private bool isAttack = false;
        private bool isHited = false;
        private float timeHit;
        private float timeToAttack;


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
            Agent.stoppingDistance = AISettings.StopDistance;
        }

        private void Update()
        {
            Move(AISettings.Target.position);
        }

        protected void Move(Vector3 Target)
        {
            if(NavMeshGeneratorAdapter.IsDone != true)return; 


            distanceToTarget = Vector3.Distance(Target, transform.position);



            switch (AISettings.AiType)
            {
                case AIType.Melee:

                    if (isHited == false)
                    {
                        Agent.isStopped = false;
                        if (distanceToTarget >= AISettings.StopDistance)
                        {
                            SetAnimatror(true,false,false,false);
                            Agent.SetDestination(Target);
                        }
                        else if(float.IsInfinity(Agent.remainingDistance) == false && isAttack == false)
                        {
                            isAttack = true;
                            Attack();
                        }
                    }
                    else
                    {
                        Agent.isStopped = true;
                    }
                        

                    break;
                case AIType.Ranged:
                    break;
                case AIType.MeleeAndRanged:
                    break;
            }
           



        }

        private void Attack()
        {
            SetAnimatror(false,true,false,false);

            isAttack = false;
        }

        public void GetHit()
        {
            isHited = true;
            SetAnimatror(false,false,false,true);
        }

        private void OnDrawGizmos()
        {

        }

        public void SetAnimatror(bool walk, bool attack, bool death, bool hit)
        {
        
        }

        public void ResetAniamtorAndStates()
        {
            SetAnimatror(false,false,false,false);
            isAttack = false;
            isHited = false;
            timeHit = 0;
            timeToAttack = 0;
        }

        public void ResetAnimator()
        {
        
        }
    }

    [Serializable]
    public struct AIStatistic { }

}
