// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Cleanable_Blood_Xtracks : Obj_Effect_Decal_Cleanable_Blood {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.random_icon_states = null;
			this.blood_DNA = new ByTable().Set( "UNKNOWN DNA", "X*" );
			this.icon_state = "xtracks";
		}

		public Obj_Effect_Decal_Cleanable_Blood_Xtracks ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}