// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Flash : Obj_Screen {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.blend_mode = 2;
			this.screen_loc = "WEST,SOUTH to EAST,NORTH";
			this.icon_state = "blank";
			this.layer = 17;
		}

		public Obj_Screen_Flash ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}