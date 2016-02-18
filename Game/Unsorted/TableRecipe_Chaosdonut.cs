// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Chaosdonut : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Chaos donut";
			this.reqs = new ByTable().Set( typeof(Reagent_Consumable_Frostoil), 5 ).Set( typeof(Reagent_Consumable_Capsaicin), 5 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pastrybase), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Donut_Chaos);
			this.category = "Food";
		}

	}

}