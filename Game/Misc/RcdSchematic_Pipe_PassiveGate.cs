// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RcdSchematic_Pipe_PassiveGate : RcdSchematic_Pipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Passive gate";
			this.category = "Devices";
			this.pipe_id = 15;
			this.pipe_type = 4;
		}

		public RcdSchematic_Pipe_PassiveGate ( dynamic n_master = null ) : base( (object)(n_master) ) {
			
		}

	}

}