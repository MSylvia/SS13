// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Nutrient_Rh : Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Nutrient {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "bottle15";
		}

		// Function from file: hydroitemdefines.dm
		public Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Nutrient_Rh ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.reagents.add_reagent( "robustharvestnutriment", 50 );
			return;
		}

	}

}