// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Adminordrazine : Obj_Item_Weapon_ReagentContainers_Glass_Bottle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/drinks.dmi";
		}

		// Function from file: bottle.dm
		public Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Adminordrazine ( dynamic loc = null, dynamic altvol = null ) : base( (object)(loc), (object)(altvol) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "adminordrazine", 30 );
			return;
		}

	}

}