// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_ChronosTarget : Obj_Screen {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.screen_loc = "CENTER,CENTER";
			this.color = "#ff3311";
			this.blend_mode = 3;
		}

		// Function from file: chronosuit.dm
		public Obj_Screen_ChronosTarget ( dynamic loc = null, Ent_Static user = null ) : base( (object)(loc) ) {
			Icon user_icon = null;

			
			if ( user != null ) {
				user_icon = GlobalFuncs.getFlatIcon( user );
				this.icon = user_icon;
				this.transform = user.transform;
			} else {
				GlobalFuncs.qdel( this );
			}
			return;
		}

	}

}