// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesyfries : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Plate);
			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 2 );
			this.list_reagents = new ByTable().Set( "nutriment", 6 );
			this.filling_color = "#FFD700";
			this.icon_state = "cheesyfries";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesyfries ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}