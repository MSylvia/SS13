// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Alien_Resin_Membrane : Obj_Structure_Alien_Resin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 120;
			this.resintype = "membrane";
			this.canSmoothWith = new ByTable(new object [] { typeof(Obj_Structure_Alien_Resin_Wall), typeof(Obj_Structure_Alien_Resin_Membrane) });
			this.icon = "icons/obj/smooth_structures/alien/resin_membrane.dmi";
			this.icon_state = "membrane0";
		}

		public Obj_Structure_Alien_Resin_Membrane ( dynamic location = null ) : base( (object)(location) ) {
			
		}

	}

}