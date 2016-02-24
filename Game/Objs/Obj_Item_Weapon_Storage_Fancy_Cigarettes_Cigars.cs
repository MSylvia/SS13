// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Fancy_Cigarettes_Cigars : Obj_Item_Weapon_Storage_Fancy_Cigarettes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.can_hold = new ByTable(new object [] { typeof(Obj_Item_Clothing_Mask_Cigarette_Cigar) });
			this.icon_type = "premium cigar";
			this.spawn_type = typeof(Obj_Item_Clothing_Mask_Cigarette_Cigar);
			this.icon_state = "cigarcase";
		}

		public Obj_Item_Weapon_Storage_Fancy_Cigarettes_Cigars ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: fancy.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			int? c = null;

			this.overlays.Cut();
			this.overlays.Add( "" + this.icon_state + "_open" );
			c = null;
			c = this.contents.len;

			while (( c ??0) >= 1) {
				this.overlays.Add( new Image( this.icon, null, this.icon_type, null, null, ( ( c ??0) - 1 ) * 4 ) );
				c--;
			}
			return false;
		}

	}

}