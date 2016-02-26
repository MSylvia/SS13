// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Implant_Exile : Obj_Item_Weapon_Implant {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=2;biotech=3;magnets=2;bluespace=3";
			this.activated = false;
		}

		public Obj_Item_Weapon_Implant_Exile ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: exile.dm
		public override string get_data(  ) {
			string dat = null;

			dat = "<b>Implant Specifications:</b><BR>\n				<b>Name:</b> Nanotrasen Employee Exile Implant<BR>\n				<b>Implant Details:</b> The onboard gateway system has been modified to reject entry by individuals containing this implant<BR>";
			return dat;
		}

	}

}