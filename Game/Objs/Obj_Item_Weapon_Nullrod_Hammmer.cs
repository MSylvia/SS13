// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Nullrod_Hammmer : Obj_Item_Weapon_Nullrod {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "hammeron";
			this.slot_flags = 512;
			this.w_class = 5;
			this.attack_verb = new ByTable(new object [] { "smashed", "bashed", "hammered", "crunched" });
			this.icon_state = "hammeron";
		}

		public Obj_Item_Weapon_Nullrod_Hammmer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}