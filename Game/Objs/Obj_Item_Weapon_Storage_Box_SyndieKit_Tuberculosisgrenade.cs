// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_SyndieKit_Tuberculosisgrenade : Obj_Item_Weapon_Storage_Box_SyndieKit {

		// Function from file: uplink_kits.dm
		public Obj_Item_Weapon_Storage_Box_SyndieKit_Tuberculosisgrenade ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Weapon_Grenade_ChemGrenade_Tuberculosis( this );

			foreach (dynamic _a in Lang13.IterateRange( 1, 5 )) {
				i = _a;
				
				new Obj_Item_Weapon_ReagentContainers_Hypospray_Medipen_Tuberculosiscure( this );
			}
			new Obj_Item_Weapon_ReagentContainers_Syringe( this );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Tuberculosiscure( this );
			return;
		}

	}

}