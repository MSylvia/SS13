// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Bible_Booze : Obj_Item_Weapon_Storage_Bible {

		// Function from file: bible.dm
		public Obj_Item_Weapon_Storage_Bible_Booze ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Weapon_ReagentContainers_Food_Drinks_Beer( this );
			new Obj_Item_Weapon_ReagentContainers_Food_Drinks_Beer( this );
			new Obj_Item_Weapon_Spacecash( this );
			new Obj_Item_Weapon_Spacecash( this );
			new Obj_Item_Weapon_Spacecash( this );
			return;
		}

	}

}