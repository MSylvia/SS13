// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Abductor_Console : Obj_Effect_Landmark_Abductor {

		// Function from file: abduction.dm
		public Obj_Effect_Landmark_Abductor_Console ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Machinery_Abductor_Console c = null;

			c = new Obj_Machinery_Abductor_Console( this.loc );
			c.team = this.team ?1:0;
			Task13.Schedule( 5, (Task13.Closure)(() => {
				c.Initialize();
				return;
			}));
			GlobalFuncs.qdel( this );
			return;
		}

	}

}