// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Nutrient_Ez : Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Nutrient {

		// Function from file: hydroitemdefines.dm
		public Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Nutrient_Ez ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.reagents.add_reagent( "eznutriment", 50 );
			return;
		}

	}

}