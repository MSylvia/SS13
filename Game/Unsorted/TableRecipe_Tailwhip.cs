// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Tailwhip : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Liz O' Nine Tails";
			this.result = typeof(Obj_Item_Weapon_Melee_Chainofcommand_Tailwhip);
			this.reqs = new ByTable().Set( typeof(Obj_Item_Organ_Severedtail), 1 ).Set( typeof(Obj_Item_Stack_CableCoil), 1 );
			this.time = 40;
			this.category = "Weaponry";
		}

	}

}