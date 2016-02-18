// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_ChemMaster : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (Chem Master Board)";
			this.desc = "The circuit board for a Chem Master 2999.";
			this.id = "chem_master";
			this.req_tech = new ByTable().Set( "biotech", 1 ).Set( "materials", 2 ).Set( "programming", 2 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_ChemMaster);
			this.category = new ByTable(new object [] { "Medical Machinery" });
		}

	}

}