// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Donut_Normal : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Donut {

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Donut_Normal ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "nutriment", 3 );
			((Reagents)this.reagents).add_reagent( "sprinkles", 1 );
			this.bitesize = 3;

			if ( Rand13.PercentChance( 30 ) ) {
				this.icon_state = "donut2";
				this.name = "frosted donut";
				((Reagents)this.reagents).add_reagent( "sprinkles", 2 );
			}
			return;
		}

	}

}