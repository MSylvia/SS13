// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Card_Id_Ert : Obj_Item_Weapon_Card_Id {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.registered_name = "Emergency Response Team Commander";
			this.assignment = "Emergency Response Team Commander";
			this.icon_state = "centcom";
		}

		// Function from file: cards_ids.dm
		public Obj_Item_Weapon_Card_Id_Ert ( dynamic loc = null ) : base( (object)(loc) ) {
			this.access = GlobalFuncs.get_all_accesses() + GlobalFuncs.get_ert_access( "commander" ) - GlobalVars.access_change_ids;
			return;
		}

	}

}