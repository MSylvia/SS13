// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Overlay_Temp_Explosion : Obj_Effect_Overlay_Temp {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pixel_x = -32;
			this.pixel_y = -32;
			this.duration = 8;
			this.icon = "icons/effects/96x96.dmi";
			this.icon_state = "explosion";
		}

		public Obj_Effect_Overlay_Temp_Explosion ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}