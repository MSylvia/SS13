// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_Flask_Det : Obj_Item_Weapon_ReagentContainers_Food_Drinks_Flask {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.materials = new ByTable().Set( "$metal", 250 );
			this.list_reagents = new ByTable().Set( "whiskey", 30 );
			this.icon_state = "detflask";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_Flask_Det ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}