// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Pod_Disposal : Obj_Machinery_Computer_Pod {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.default_loop = true;
			this.default_time = 10;
			this.default_timings = true;
			this.id_tags = new ByTable(new object [] { "disposal_network" });
		}

		public Obj_Machinery_Computer_Pod_Disposal ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}