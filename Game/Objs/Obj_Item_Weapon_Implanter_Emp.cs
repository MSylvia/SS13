// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Implanter_Emp : Obj_Item_Weapon_Implanter {

		// Function from file: implanter.dm
		public Obj_Item_Weapon_Implanter_Emp ( dynamic loc = null ) : base( (object)(loc) ) {
			this.imp = new Obj_Item_Weapon_Implant_Emp( this );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}