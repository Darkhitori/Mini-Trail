using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiny;

namespace Darkhitori.PlaymakerActions._MiniTrail
{
	using HutongGames.PlayMaker;

	[ActionCategory("MiniTrail")]
	[Tooltip("")]
	public class GetLoop : FsmStateAction
	{
        #region Variables
		[RequiredField]
		[CheckForComponent(typeof(Trail))]
		public FsmOwnerDefault gameObject;
        
		[UIHint(UIHint.Variable)]
		public FsmBool loop;
		
		public FsmEvent trueEvent;
		
		public FsmEvent falseEvent;
        
		[Tooltip("Repeat every frame.")]
		public bool everyFrame;
        
		Trail trailComp;
        #endregion
        
        #region Reset Values
		public override void Reset()
		{
			gameObject = null;
			loop = false;
			trueEvent = null;
			falseEvent = null;
			everyFrame = false;
		}
        #endregion
        
        #region Methods
		// Code that runs on entering the state.
		public override void OnEnter()
		{
			DoMethod();
			if (!everyFrame)
			{
				Finish();
			}
		}
        
		// Code that runs every frame.
		public override void OnUpdate()
		{
			DoMethod();
		}

		void DoMethod()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if(go == null)
			{
				return;
			}
            
			trailComp = go.GetComponent<Trail>();
            
			loop.Value = trailComp.Loop;
			
			Fsm.Event(loop.Value ? trueEvent : falseEvent);
            
		}
        #endregion
	}

}
