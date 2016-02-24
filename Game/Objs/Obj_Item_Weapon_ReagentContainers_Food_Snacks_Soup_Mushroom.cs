// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Mushroom : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 5 );
			this.list_reagents = new ByTable().Set( "nutriment", 8 ).Set( "vitamin", 4 );
			this.icon_state = "mushroomsoup";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Mushroom ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}