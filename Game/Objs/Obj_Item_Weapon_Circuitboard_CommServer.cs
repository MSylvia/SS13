// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_CommServer : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = typeof(Obj_Machinery_Computer_Telecomms_Server);
			this.origin_tech = "programming=3";
		}

		public Obj_Item_Weapon_Circuitboard_CommServer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}