// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_Engineer : Obj_Item_Weapon_Storage_Box {

		// Function from file: boxes.dm
		public Obj_Item_Weapon_Storage_Box_Engineer ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.contents = new ByTable();
			new Obj_Item_Clothing_Mask_Breath( this );
			new Obj_Item_Weapon_Tank_Internals_EmergencyOxygen_Engi( this );
			new Obj_Item_Weapon_ReagentContainers_Hypospray_Medipen( this );
			return;
		}

	}

}