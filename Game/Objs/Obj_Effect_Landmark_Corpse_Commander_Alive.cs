// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Corpse_Commander_Alive : Obj_Effect_Landmark_Corpse_Commander {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.death = false;
			this.roundstart = false;
			this.mobname = "Nanotrasen Commander";
			this.flavour_text = "You are a Nanotrasen Commander!";
			this.icon = "icons/obj/Cryogenic2.dmi";
			this.icon_state = "sleeper";
		}

		public Obj_Effect_Landmark_Corpse_Commander_Alive ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}