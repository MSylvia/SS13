// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Condiment_Milk : Obj_Item_Weapon_ReagentContainers_Food_Condiment {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "carton";
			this.list_reagents = new ByTable().Set( "milk", 50 );
			this.possible_states = new ByTable();
			this.icon_state = "milk";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Condiment_Milk ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}