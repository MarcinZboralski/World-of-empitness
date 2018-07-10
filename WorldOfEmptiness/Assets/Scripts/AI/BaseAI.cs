using System;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    [Serializable]
    public class BaseAI : MonoBehaviour, AIAniamtor
    {
        public AISettings AISettings;
        public AIStatistic AIStatistic;

        private NavMeshAgent Agent;
        private float distanceToTarget;
        private bool isAttack = false;
        private bool isHited = false;
        private float timeHit;
        private float timeToAttack;


        public float DistanceToTarget
        {
            get { return distanceToTarget; }
        }

        public bool IsWalking
        {
            get { return Agent.isStopped; }
        }

        public bool IsAttack
        {
            get { return isAttack; }
        }

        public bool IsHited
        {
            get { return isHited; }
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
            if (NavMeshGeneratorAdapter.IsDone == false) return;

            distanceToTarget = Vector3.Distance(Target, transform.position);

            switch (AISettings.AiType)
            {
                case AIType.Melee:

                    if (isHited == false)
                    {
                        Agent.isStopped = false;
                        if (distanceToTarget >= AISettings.StopDistance)
                        {
                            SetAnimatror(true, false, false, false);
                            Agent.SetDestination(Target);
                        }
                        else if (isAttack == false && timeToAttack > 0 && Agent.remainingDistance <= distanceToTarget)
                        {
                            SetAnimatror(false, true, false, false);
                            Agent.isStopped = true;
                            timeToAttack -= Time.smoothDeltaTime;
                            if (isAttack == false && timeToAttack <= 0)
                            {
                                Attack();
                            }

                        }
                    }
                    else
                    {
                        Agent.isStopped = true;
                        if (timeHit > 0)
                        {
                            timeHit -= Time.smoothDeltaTime;
                        }

                        if (timeHit <= 0)
                        {
                            EndHit();
                        }

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
            if (isAttack == false)
            {
                switch (AISettings.AiType)
                {
                    case AIType.Melee:

                        break;
                    case AIType.Ranged:

                        break;
                    case AIType.MeleeAndRanged:

                        break;
                }
                isAttack = true;
                Agent.isStopped = false;
            }
        }

        public void GetHit()
        {
            if (isHited == false)
            {
                isHited = true;
                SetAnimatror(false, false, false, true);
            }
        }

        private void EndHit()
        {
            if (isHited)
            {
                isHited = false;
            }
        }

        private void OnDrawGizmos()
        {

        }

        public void SetAnimatror(bool walk, bool attack, bool death, bool hit)
        {

        }

        public void ResetAniamtor()
        {
            SetAnimatror(false, false, false, false);
        }

        public void ResetStates()
        {
            Agent.isStopped = false;
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
    public struct AIStatistic
    {
    }

}
