// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Mecha_Combat_Reticence_Loaded : Obj_Mecha_Combat_Reticence {

		// Function from file: tgstation.dme
		public Obj_Mecha_Combat_Reticence_Loaded ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Item_MechaParts_MechaEquipment ME = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			ME = new Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Silenced();
			ME.attach( this );
			ME = new Obj_Item_MechaParts_MechaEquipment_Rcd();
			ME.attach( this );
			return;
		}

	}

}