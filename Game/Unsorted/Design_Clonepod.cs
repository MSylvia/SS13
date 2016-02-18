// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Clonepod : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (Clone Pod)";
			this.desc = "Allows for the construction of circuit boards used to build a Cloning Pod.";
			this.id = "clonepod";
			this.req_tech = new ByTable().Set( "programming", 3 ).Set( "biotech", 3 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Clonepod);
			this.category = new ByTable(new object [] { "Medical Machinery" });
		}

	}

}