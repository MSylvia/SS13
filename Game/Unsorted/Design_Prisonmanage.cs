// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Prisonmanage : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Computer Design (Prisoner Management Console)";
			this.desc = "Allows for the construction of circuit boards used to build a prisoner management console.";
			this.id = "prisonmanage";
			this.req_tech = new ByTable().Set( "programming", 2 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Prisoner);
			this.category = new ByTable(new object [] { "Computer Boards" });
		}

	}

}