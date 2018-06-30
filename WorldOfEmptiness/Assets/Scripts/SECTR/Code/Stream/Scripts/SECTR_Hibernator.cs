// Copyright (c) 2014 Make Code Now! LLC

using UnityEngine;
using System.Collections;

/// \ingroup Stream
/// Automatically enables and disables components on itself when the SECTR_Sector it's part of are
/// (un)loaded.
/// 
/// It's often useful to have global objects that are always instantiated, even when their
/// part of the scene is not loaded. However, because their area is not loaded, these objets may
/// not want to update until their areas are active again. SECTR_Hibernator takes care of
/// this behavior automatically, taking care of physics and behaviors, while providing optional
/// Events to notify anyone who might be interested in things that happen while hibernated.
[RequireComponent(typeof(SECTR_Member))]
[AddComponentMenu("SECTR/Stream/SECTR Hibernator")]
public class SECTR_Hibernator : MonoBehaviour 
{
	#region Private Details
	private bool hibernating = false;
	private SECTR_Member cachedMember = null;
	#endregion

	#region Public Interface
	[SECTR_ToolTip("Hibernate components on children as well as ones on this game object.")]
	public bool HibernateChildren = true;
	[SECTR_ToolTip("Disable Behavior components during hibernation.")] 
	public bool HibernateBehaviors = true;
	[SECTR_ToolTip("Disable Collder components during hibernation.")]
	public bool HibernateColliders = true;
	[SECTR_ToolTip("Disable RigidBody components during hibernation.")]
	public bool HibernateRigidBodies = true;
	[SECTR_ToolTip("Hide Render components during hibernation.")]
	public bool HibernateRenderers = true;
	[SECTR_ToolTip("Apply hibernation to an alternate entity.")]
	public GameObject HibernateTarget = null;

	/// Delegate delcaration for anyone who wants to be notified on hibernation related events.
	public delegate void HibernateCallback();
	
	/// Event handler for when we go from hiberanted to awake.
	public event HibernateCallback Awoke;
	/// Event handler for when we go from awake to hibernate.
	public event HibernateCallback Hibernated;
	/// Event handler for updates during hibernation. Use judiciously.
	public event HibernateCallback HibernateUpdate;
	#endregion

	#region Unity Interface
	void OnEnable()
	{
		cachedMember = GetComponent<SECTR_Member>();
	}

	// This needs to be guaranteed happen before other SECTR updates to prevent
	// one frame of falling.
	void FixedUpdate() 
	{
		bool allSectorsFrozen = true;
		int numSectors = cachedMember.Sectors.Count;
		for(int sectorIndex = 0; sectorIndex < numSectors; ++sectorIndex)
		{
			SECTR_Sector sector = cachedMember.Sectors[sectorIndex];
			if(!sector.Frozen)
			{
				allSectorsFrozen = false;
				break;
			}
		}

		if(allSectorsFrozen && !hibernating)
		{
			_Hibernate();
		}
		else if(!allSectorsFrozen && hibernating)
		{
			_WakeUp();
		}

		if(hibernating && HibernateUpdate != null)
		{
			HibernateUpdate();
		}
	}
	#endregion

	#region Private Methods
	void _WakeUp()
	{
		if(hibernating)
		{
			hibernating = false;
			_UpdateComponents();
			if(Awoke != null)
			{
				Awoke();
			}
		}
	}

	void _Hibernate()
	{
		if(!hibernating)
		{
			hibernating = true;
			_UpdateComponents();
			if(Hibernated != null)
			{
				Hibernated();
			}
		}
	}

	void _UpdateComponents()
	{
		GameObject hibernatedObject = HibernateTarget ? HibernateTarget : gameObject;

		if(HibernateBehaviors)
		{
			Behaviour[] behaviors = HibernateChildren ? hibernatedObject.GetComponentsInChildren<Behaviour>() : hibernatedObject.GetComponents<Behaviour>();
			int numBehaviors = behaviors.Length;
			for(int behaviorIndex = 0; behaviorIndex < numBehaviors; ++behaviorIndex)
			{
				Behaviour behavior = behaviors[behaviorIndex];
				if(behavior.GetType() != typeof(SECTR_Hibernator) && behavior.GetType() != typeof(SECTR_Member))
				{
					behavior.enabled = !hibernating;
				}
			}
		}

		if(HibernateRigidBodies)
		{
			Rigidbody[] bodies =  HibernateChildren ? hibernatedObject.GetComponentsInChildren<Rigidbody>() : hibernatedObject.GetComponents<Rigidbody>();
			int numBodies = bodies.Length;
			for(int bodyIndex = 0; bodyIndex < numBodies; ++bodyIndex)
			{
				Rigidbody body = bodies[bodyIndex];
				if(hibernating)
				{
					body.Sleep();
				}
				else
				{
					body.WakeUp();
				}
			}
		}

		if(HibernateColliders)
		{
			Collider[] colliders =  HibernateChildren ? hibernatedObject.GetComponentsInChildren<Collider>() : hibernatedObject.GetComponents<Collider>();
			int numColliders = colliders.Length;
			for(int colliderIndex = 0; colliderIndex < numColliders; ++colliderIndex)
			{
				colliders[colliderIndex].enabled = !hibernating;
			}
		}

		if(HibernateRenderers)
		{
			Renderer[] renderers =  HibernateChildren ? hibernatedObject.GetComponentsInChildren<Renderer>() : hibernatedObject.GetComponents<Renderer>();
			int numRenderers = renderers.Length;
			for(int rendererIndex = 0; rendererIndex < numRenderers; ++rendererIndex)
			{
				renderers[rendererIndex].enabled = !hibernating;
			}
		}
	}
	#endregion
}
