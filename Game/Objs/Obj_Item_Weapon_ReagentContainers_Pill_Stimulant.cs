// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Pill_Stimulant : Obj_Item_Weapon_ReagentContainers_Pill {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "ephedrine", 10 ).Set( "antihol", 10 ).Set( "coffee", 30 );
			this.roundstart = true;
			this.icon_state = "pill19";
		}

		public Obj_Item_Weapon_ReagentContainers_Pill_Stimulant ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}