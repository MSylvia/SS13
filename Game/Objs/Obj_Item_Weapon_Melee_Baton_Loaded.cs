// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Melee_Baton_Loaded : Obj_Item_Weapon_Melee_Baton {

		// Function from file: stunbaton.dm
		public Obj_Item_Weapon_Melee_Baton_Loaded ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.bcell = new Obj_Item_Weapon_StockParts_Cell_High( this );
			this.update_icon();
			return;
		}

	}

}