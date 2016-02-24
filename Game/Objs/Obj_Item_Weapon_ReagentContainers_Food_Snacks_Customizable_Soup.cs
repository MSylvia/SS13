// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable_Soup : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bowl);
			this.ingMax = 8;
			this.icon = "icons/obj/food/soupsalad.dmi";
			this.icon_state = "wishsoup";
		}

		// Function from file: customizables.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable_Soup ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.eatverb = Rand13.Pick(new object [] { "slurp", "sip", "suck", "inhale", "drink" });
			return;
		}

	}

}