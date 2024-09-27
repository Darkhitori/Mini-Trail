using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiny;

namespace Darkhitori.PlaymakerActions._MiniTrail
{
	using HutongGames.PlayMaker;

	[ActionCategory("MiniTrail")]
	[Tooltip("Removes all points from the TrailRenderer. Useful for restarting a trail from a new position.")]
	public class Clear : FsmStateAction
	{
        #region Variables
		[RequiredField]
		[CheckForComponent(typeof(Trail))]
		public FsmOwnerDefault gameObject;
        
		[Tooltip("Repeat every frame.")]
		public bool everyFrame;
        
		Trail trailComp;
        #endregion
        
        #region Reset Values
		public override void Reset()
		{
			gameObject = null;
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
            
			trailComp.Clear();
            
		}
        #endregion
	}

}
