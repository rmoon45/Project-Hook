using System;
using A2DK.Phys;
using Mechanics.GrappleBehaviors.PullBehavior;
using Phys.PhysObjStateMachine;
using UnityEngine;

namespace Mechanics
{
    public class PullBehaviorStateMachine : PhysObjStateMachine<PullBehaviorStateMachine, PullBehaviorState, PullBehaviorStateInput, Actor>
    {
        public PullBehavior MyPullBehavior { get; private set; }
        
        protected override void SetInitialState() => SetState<Idle>();

        protected override void Init()
        {
            base.Init();
            MyPullBehavior = GetComponent<PullBehavior>();
        }
    }

    public abstract class PullBehaviorState : PhysObjStateMachine.PhysObjState<PullBehaviorStateMachine, PullBehaviorState, PullBehaviorStateInput, Actor>
    {
        public virtual void AttachGrapple() {}
        public virtual void DetachGrapple() {}
        public virtual void StickyEnter(Vector2 myActorVelocity, Transform sticky) {}
        public virtual void StickyExit() {}

        public abstract void ContinuousGrapplePos(Vector2 grappleVector, Actor grappledActor);
    }

    public class PullBehaviorStateInput : PhysObjStateInput
    {
        public bool KeepV;
        public Vector2 BeforeStickyV;
        public Transform Sticky;
    }
}