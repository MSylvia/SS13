// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Shuttle_Ferry : Obj_Machinery_Computer_Shuttle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.circuit = typeof(Obj_Item_Weapon_Circuitboard_Ferry);
			this.shuttleId = "ferry";
			this.possible_destinations = "ferry_home;ferry_away";
		}

		public Obj_Machinery_Computer_Shuttle_Ferry ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			
		}

	}

}