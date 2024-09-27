using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiny;

namespace Darkhitori.PlaymakerActions._MiniTrail
{
	using HutongGames.PlayMaker;

	[ActionCategory("MiniTrail")]
	[Tooltip("The array of Vector3 points to connect.")]
	public class SetPoints : FsmStateAction
	{
        #region Variables
		[RequiredField]
		[CheckForComponent(typeof(Trail))]
		public FsmOwnerDefault gameObject;
        
		[ArrayEditor(VariableType.Vector3)]
		public FsmArray points;
		
		[Tooltip("Repeat every frame.")]
		public bool everyFrame;
        
		Trail trailComp;
        #endregion
        
        #region Reset Values
		public override void Reset()
		{
			gameObject = null;
			points = null;
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
            
			trailComp.Points = points.Vec3ToArray();
            
		}
        #endregion
	}

}
