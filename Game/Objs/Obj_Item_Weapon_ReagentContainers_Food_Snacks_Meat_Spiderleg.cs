// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Spiderleg : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.food_flags = 1;
			this.icon_state = "spiderleg";
		}

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Spiderleg ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.poisonsacs = new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Spiderpoisongland();
			((Reagents)this.reagents).add_reagent( "nutriment", 2 );
			((Reagents)this.reagents).add_reagent( "toxin", 2 );
			this.bitesize = 2;
			return;
		}

	}

}