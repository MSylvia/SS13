// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_ChemDispenser : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (Portable Chem Dispenser Board)";
			this.desc = "The circuit board for a portable chem dispenser.";
			this.id = "chem_dispenser";
			this.req_tech = new ByTable().Set( "programming", 4 ).Set( "biotech", 3 ).Set( "engineering", 4 ).Set( "materials", 4 ).Set( "plasmatech", 3 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_ChemDispenser);
			this.category = new ByTable(new object [] { "Medical Machinery" });
		}

	}

}