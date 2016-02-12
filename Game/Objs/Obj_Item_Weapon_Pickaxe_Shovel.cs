// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Pickaxe_Shovel : Obj_Item_Weapon_Pickaxe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 8;
			this.item_state = "shovel";
			this.sharpness = 0.5;
			this.w_type = 1;
			this.attack_verb = new ByTable(new object [] { "bashed", "bludgeoned", "thrashed", "whacked" });
			this.diggables = 2;
			this.icon_state = "shovel";
		}

		public Obj_Item_Weapon_Pickaxe_Shovel ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}