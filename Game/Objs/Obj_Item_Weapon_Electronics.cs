// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Electronics : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "electronic";
			this.flags = 64;
			this.w_class = 2;
			this.origin_tech = "engineering=2;programming=1";
			this.materials = new ByTable().Set( "$metal", 50 ).Set( "$glass", 50 );
			this.icon = "icons/obj/module.dmi";
			this.icon_state = "door_electronics";
		}

		public Obj_Item_Weapon_Electronics ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}