// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Ratburger : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Rat burger";
			this.reqs = new ByTable().Set( typeof(Obj_Item_Trash_Deadmouse), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bun), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Rat);
			this.category = "Food";
		}

	}

}