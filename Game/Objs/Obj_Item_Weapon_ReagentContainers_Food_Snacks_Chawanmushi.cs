// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chawanmushi : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "vitamin", 1 );
			this.list_reagents = new ByTable().Set( "nutriment", 5 );
			this.filling_color = "#FFE4E1";
			this.icon_state = "chawanmushi";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chawanmushi ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}