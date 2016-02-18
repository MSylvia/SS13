// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Fishburger : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Fish burger";
			this.reqs = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Carpmeat), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bun), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Fish);
			this.category = "Food";
		}

	}

}