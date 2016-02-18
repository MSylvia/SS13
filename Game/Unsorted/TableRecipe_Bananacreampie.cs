// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Bananacreampie : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Banana cream pie";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Consumable_Milk), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Plain), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Banana), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Cream);
			this.category = "Food";
		}

	}

}