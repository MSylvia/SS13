// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Condiment_Saltshaker : Obj_Item_Weapon_ReagentContainers_Food_Condiment {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.possible_transfer_amounts = new ByTable(new object [] { 1, 20 });
			this.amount_per_transfer_from_this = 1;
			this.volume = 20;
			this.list_reagents = new ByTable().Set( "sodiumchloride", 20 );
			this.possible_states = new ByTable();
			this.icon_state = "saltshakersmall";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Condiment_Saltshaker ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}