// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Monkeysdelight : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Monkeys delight";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Consumable_Flour), 5 )
				.Set( typeof(Reagent_Consumable_Sodiumchloride), 1 )
				.Set( typeof(Reagent_Consumable_Blackpepper), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bowl), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Monkeycube), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Banana), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Monkeysdelight);
			this.category = "Food";
		}

	}

}