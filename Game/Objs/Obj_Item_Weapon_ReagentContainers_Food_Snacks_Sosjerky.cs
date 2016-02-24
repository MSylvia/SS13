// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sosjerky : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Sosjerky);
			this.list_reagents = new ByTable().Set( "nutriment", 1 ).Set( "sugar", 3 );
			this.junkiness = 25;
			this.filling_color = "#8B0000";
			this.icon_state = "sosjerky";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sosjerky ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}