// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Damageoverlay : Obj_Screen {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.blend_mode = 4;
			this.screen_loc = "CENTER-7,CENTER-7";
			this.icon = "icons/mob/screen_full.dmi";
			this.icon_state = "oxydamageoverlay0";
			this.layer = 18.1;
		}

		public Obj_Screen_Damageoverlay ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}