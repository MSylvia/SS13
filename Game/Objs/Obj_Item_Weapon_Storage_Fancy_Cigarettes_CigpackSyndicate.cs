// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Fancy_Cigarettes_CigpackSyndicate : Obj_Item_Weapon_Storage_Fancy_Cigarettes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "syndie";
		}

		// Function from file: fancy.dm
		public Obj_Item_Weapon_Storage_Fancy_Cigarettes_CigpackSyndicate ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.IterateRange( 1, this.storage_slots )) {
				i = _a;
				
				this.reagents.add_reagent( "omnizine", 15 );
			}
			return;
		}

	}

}