// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Toxin : Obj_Item_Weapon_ReagentContainers_Glass_Bottle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "toxin", 30 );
			this.icon_state = "bottle12";
		}

		public Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Toxin ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}