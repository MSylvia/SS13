// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Notasandwich : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Not a sandwich";
			this.reqs = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Breadslice_Plain), 2 ).Set( typeof(Obj_Item_Clothing_Mask_Fakemoustache), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Notasandwich);
			this.category = "Food";
		}

	}

}