// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Cigbutt_Roach : Obj_Item_Weapon_Cigbutt {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "roach";
		}

		// Function from file: cigs_lighters.dm
		public Obj_Item_Weapon_Cigbutt_Roach ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pixel_x = Rand13.Int( -5, 5 );
			this.pixel_y = Rand13.Int( -5, 5 );
			return;
		}

	}

}