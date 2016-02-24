// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Copypasta : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Plate);
			this.bitesize = 4;
			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 4 );
			this.list_reagents = new ByTable().Set( "nutriment", 12 ).Set( "tomatojuice", 20 ).Set( "vitamin", 8 );
			this.filling_color = "#DC143C";
			this.icon = "icons/obj/food/pizzaspaghetti.dmi";
			this.icon_state = "copypasta";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Copypasta ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}