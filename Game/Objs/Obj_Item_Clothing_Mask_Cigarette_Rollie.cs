// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Cigarette_Rollie : Obj_Item_Clothing_Mask_Cigarette {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_on = "spliffon";
			this.icon_off = "spliffoff";
			this.type_butt = typeof(Obj_Item_Weapon_Cigbutt_Roach);
			this.item_state = "spliffoff";
			this.smoketime = 180;
			this.chem_volume = 50;
			this.icon_state = "spliffoff";
		}

		// Function from file: cigs_lighters.dm
		public Obj_Item_Clothing_Mask_Cigarette_Rollie ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pixel_x = Rand13.Int( -5, 5 );
			this.pixel_y = Rand13.Int( -5, 5 );
			return;
		}

	}

}