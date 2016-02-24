// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Stew : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "tomatojuice", 5 ).Set( "vitamin", 5 );
			this.list_reagents = new ByTable().Set( "nutriment", 10 ).Set( "oculine", 5 ).Set( "tomatojuice", 5 ).Set( "vitamin", 5 );
			this.bitesize = 7;
			this.volume = 100;
			this.icon_state = "stew";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Stew ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}