// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Buildmode_Dir : Obj_Screen_Buildmode {

		public Obj_Screen_Buildmode_Dir ( dynamic bd = null ) : base( (object)(bd) ) {
			
		}

		// Function from file: buildmode.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			((Buildmode)this.bd).change_dir();
			this.update_icon();
			return true;
		}

	}

}