// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Flamethrower_Full_Tank : Obj_Item_Weapon_Flamethrower_Full {

		// Function from file: flamethrower.dm
		public Obj_Item_Weapon_Flamethrower_Full_Tank ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.ptank = new Obj_Item_Weapon_Tank_Internals_Plasma_Full( this );
			this.update_icon();
			return;
		}

	}

}