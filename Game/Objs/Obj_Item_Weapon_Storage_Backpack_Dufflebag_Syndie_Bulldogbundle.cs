// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Backpack_Dufflebag_Syndie_Bulldogbundle : Obj_Item_Weapon_Storage_Backpack_Dufflebag_Syndie {

		// Function from file: backpack.dm
		public Obj_Item_Weapon_Storage_Backpack_Dufflebag_Syndie_Bulldogbundle ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.contents = new ByTable();
			new Obj_Item_AmmoBox_Magazine_M12g( this );
			new Obj_Item_Weapon_Gun_Projectile_Automatic_Shotgun_Bulldog( this );
			new Obj_Item_AmmoBox_Magazine_M12g_Buckshot( this );
			new Obj_Item_Clothing_Glasses_Thermal_Syndi( this );
			return;
		}

	}

}