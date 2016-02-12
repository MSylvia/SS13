// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_Lights : Obj_Item_Weapon_Storage_Box {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.foldable = typeof(Obj_Item_Stack_Sheet_Cardboard);
			this.storage_slots = 21;
			this.can_hold = new ByTable(new object [] { "/obj/item/weapon/light/tube", "/obj/item/weapon/light/bulb" });
			this.max_combined_w_class = 21;
			this.use_to_pickup = true;
			this.icon_state = "light";
		}

		public Obj_Item_Weapon_Storage_Box_Lights ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}