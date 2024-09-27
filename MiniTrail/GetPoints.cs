using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiny;

namespace Darkhitori.PlaymakerActions._MiniTrail
{
	using HutongGames.PlayMaker;

	[ActionCategory("MiniTrail")]
	[Tooltip("Get array of Vector3 points that connect.")]
	public class GetPoints : FsmStateAction
	{
        #region Variables
		[RequiredField]
		[CheckForComponent(typeof(Trail))]
		public FsmOwnerDefault gameObject;
        
		[UIHint(UIHint.Variable)]
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
            
			var _points = trailComp.Points;
            
			points.Resize(_points.Length);
			
			for (int i = 0; i < _points.Length; i++) 
			{
				points.Set(i, _points[i]);
			}
            
		}
        #endregion
	}

}
