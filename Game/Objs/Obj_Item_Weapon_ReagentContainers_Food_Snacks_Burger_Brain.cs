// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Brain : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 6 ).Set( "mannitol", 6 ).Set( "vitamin", 5 );
			this.list_reagents = new ByTable().Set( "nutriment", 6 ).Set( "mannitol", 5 ).Set( "vitamin", 1 );
			this.icon_state = "brainburger";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Brain ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}