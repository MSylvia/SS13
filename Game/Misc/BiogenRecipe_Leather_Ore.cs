// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class BiogenRecipe_Leather_Ore : BiogenRecipe_Leather {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cost = 350;
			this.id = "ore";
			this.name = "Mining Satchel";
			this.result = typeof(Obj_Item_Weapon_Storage_Bag_Ore);
		}

	}

}