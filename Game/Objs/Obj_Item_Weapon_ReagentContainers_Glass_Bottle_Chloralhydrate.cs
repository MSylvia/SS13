// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Chloralhydrate : Obj_Item_Weapon_ReagentContainers_Glass_Bottle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "chloralhydrate", 15 );
			this.icon_state = "bottle20";
		}

		public Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Chloralhydrate ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}