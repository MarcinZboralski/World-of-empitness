using System;
using System.Security.Cryptography;
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
        private bool isDeath = false;
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
            
            AISettings.AiStatistic.MaxHelath = 10;
            AISettings.AiStatistic.ActualHealth = AISettings.AiStatistic.MaxHelath;
            Init();
        }

        public virtual void Init()
        {
            AISettings.AiStatistic.StopDistance = 1f;
            Agent.stoppingDistance = AISettings.AiStatistic.StopDistance + (Agent.radius * 2.85f + 0.4f);

            timeHit = AISettings.AiStatistic.TimeToNextAttack;
            timeToAttack = AISettings.AiStatistic.TimeToNextAttack;




            switch (AISettings.AiType)
            {
                case AIType.Melee:

                    break;
                case AIType.Ranged:

                    break;
                case AIType.MeleeAndRanged:

                    break;
            }
        }

        private void Update()
        {
            if (AISettings.AiStatistic.ActualHealth <= 0)
            {
                Destroy(gameObject);
                isDeath = true;
            }

            if(Input.GetKeyDown(KeyCode.G)){GetHit(1);}
            UseAI(AISettings.Target.position);
        }

        protected void UseAI(Vector3 Target)
        {

            if(isDeath == true)return;
          //  if (NavMeshGeneratorAdapter.IsDone == false) return;

            distanceToTarget = Vector3.Distance(Target, transform.position);

            switch (AISettings.AiType)
            {
                case AIType.Melee:

                    if (isHited == false)
                    {
                        timeHit = AISettings.AiStatistic.TimeToNextAttack;
                        if (distanceToTarget >Agent.stoppingDistance)
                        {
                            timeToAttack = AISettings.AiStatistic.TimeToNextAttack;
                            isAttack = false;
                            Agent.isStopped = false;
                            print("Move");
                            SetAnimatror(true, false, false, false);
                            Agent.SetDestination(Target);
                        }
                        else
                        {
                          //  transform.rotation = Quaternion.Euler(0, AISettings.Target.transform.rotation.eulerAngles.y, 0);
                            print("COMING");
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
                        print("Is hit");
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

        private void Death()
        {

        }

        private void Attack()
        {
            print("Is Attack");
            timeToAttack = AISettings.AiStatistic.TimeToNextAttack;
            isAttack = true;
            Agent.isStopped = false;
            isAttack = false;
        }

        public void GetHit(int demage)
        {
            if (isHited == false)
            {
                print("Hit");
                AISettings.AiStatistic.ActualHealth -= demage;
                isHited = true;
                SetAnimatror(false, false, false, true);
            }
        }

        private void EndHit()
        {
            if (isHited)
            {
                isHited = false;
                timeHit = AISettings.AiStatistic.TimeToNextAttack;
                print("EndHit");
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
        #region Global Stats

        private int actualHealth;
        private int maxHelath;
        private float timeToNextAttack;
        private Vector2 randomDemage;
        private float attackDistance;
        private float aiMaxSpeed;
        private int chancheToBlockAttack;
        private float endHitTime;
        private float stopDistance;
        #endregion

        #region Mele

        private int bleedingDemage;
        private const float bleedingTime = 1f;
        private float bleedingTimer;
        #endregion

        #region Range And MeleAndRange

        private int currentAmmo;
        private const float demagePerDistance = 0.5f;
        private int chancheToCounterAttack;
        private float rangeStopDistance;
        #endregion

        #region Hermeted 
        public int ActualHealth
        {
            get
            {
                return actualHealth;
            }

            set
            {
                actualHealth = value;
            }
        }

        public int MaxHelath
        {
            get
            {
                return maxHelath;
            }

            set
            {
                maxHelath = value;
            }
        }

        public float TimeToNextAttack
        {
            get
            {
                return timeToNextAttack;
            }

            set
            {
                timeToNextAttack = value;
            }
        }

        public Vector2 RandomDemage
        {
            get
            {
                return randomDemage;
            }

            set
            {
                randomDemage = value;
            }
        }

        public float AttackDistance
        {
            get
            {
                return attackDistance;
            }

            set
            {
                attackDistance = value;
            }
        }

        public float AiMaxSpeed
        {
            get
            {
                return aiMaxSpeed;
            }

            set
            {
                aiMaxSpeed = value;
            }
        }

        public int ChancheToBlockAttack
        {
            get
            {
                return chancheToBlockAttack;
            }

            set
            {
                chancheToBlockAttack = value;
            }
        }

        public float EndHitTime
        {
            get
            {
                return endHitTime;
            }

            set
            {
                endHitTime = value;
            }
        }

        public int BleedingDemage
        {
            get
            {
                return bleedingDemage;
            }

            set
            {
                bleedingDemage = value;
            }
        }

        public static float BleedingTime
        {
            get
            {
                return bleedingTime;
            }
        }

        public float BleedingTimer
        {
            get
            {
                return bleedingTimer;
            }

            set
            {
                bleedingTimer = value;
            }
        }

        public int CurrentAmmo
        {
            get
            {
                return currentAmmo;
            }

            set
            {
                currentAmmo = value;
            }
        }

        public static float DemagePerDistance
        {
            get
            {
                return demagePerDistance;
            }
        }

        public int ChancheToCounterAttack
        {
            get
            {
                return chancheToCounterAttack;
            }

            set
            {
                chancheToCounterAttack = value;
            }
        }

        public float StopDistance
        {
            get
            {
                return stopDistance;
            }

            set
            {
                stopDistance = value;
            }
        }

        public float RangeStopDistance
        {
            get
            {
                return rangeStopDistance;
            }

            set
            {
                rangeStopDistance = value;
            }
        }
        #endregion

    }
    
}
