// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_ClownShoes : Obj_Item_Clothing_Shoes {

		public int footstep = 1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "clown_shoes";
			this.slowdown = 1;
			this.item_color = "clown";
			this.can_hold_items = true;
			this.valid_held_items = new ByTable(new object [] { typeof(Obj_Item_Weapon_Bikehorn) });
			this.icon_state = "clown";
		}

		public Obj_Item_Clothing_Shoes_ClownShoes ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: miscellaneous.dm
		public override void step_action(  ) {
			
			if ( this.footstep > 1 ) {
				GlobalFuncs.playsound( this, "clownstep", 50, 1 );
				this.footstep = 0;
			} else {
				this.footstep++;
			}
			return;
		}

	}

}