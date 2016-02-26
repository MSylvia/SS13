// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Paint : Obj_Item_Weapon {

		public int paintleft = 10;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_color = "FFFFFF";
			this.item_state = "paintcan";
			this.burn_state = 0;
			this.burntime = 5;
			this.icon_state = "paint_neutral";
		}

		public Obj_Item_Weapon_Paint ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: paint.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( this.paintleft <= 0 ) {
				this.icon_state = "paint_empty";
				return false;
			}

			if ( !( target is Tile ) || target is Tile_Space ) {
				return false;
			}
			target.color = "#" + this.item_color;
			return false;
		}

	}

}