// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_Sillycup : Obj_Item_Weapon_ReagentContainers_Food_Drinks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.possible_transfer_amounts = new ByTable();
			this.volume = 10;
			this.spillable = true;
			this.icon_state = "water_cup_e";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_Sillycup ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

		// Function from file: drinks.dm
		public override void on_reagent_change(  ) {
			
			if ( Lang13.Bool( this.reagents.total_volume ) ) {
				this.icon_state = "water_cup";
			} else {
				this.icon_state = "water_cup_e";
			}
			return;
		}

	}

}