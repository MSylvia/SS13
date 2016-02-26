// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Window_Reinforced_Fulltile_Ice : Obj_Structure_Window_Reinforced_Fulltile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.maxhealth = 150;
			this.canSmoothWith = new ByTable(new object [] { 
				typeof(Obj_Structure_Window_Fulltile), 
				typeof(Obj_Structure_Window_Reinforced_Fulltile), 
				typeof(Obj_Structure_Window_Reinforced_Tinted_Fulltile), 
				typeof(Obj_Structure_Window_Reinforced_Fulltile_Ice)
			 });
			this.icon = "icons/obj/smooth_structures/rice_window.dmi";
			this.icon_state = "ice_window";
		}

		public Obj_Structure_Window_Reinforced_Fulltile_Ice ( dynamic Loc = null, bool? re = null ) : base( (object)(Loc), re ) {
			
		}

	}

}