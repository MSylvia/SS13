// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Bearypie : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 2 ).Set( "vitamin", 3 );
			this.list_reagents = new ByTable().Set( "nutriment", 2 ).Set( "vitamin", 3 );
			this.icon_state = "bearypie";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Bearypie ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}