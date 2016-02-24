// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Sink_Puddle : Obj_Structure_Sink {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "puddle";
		}

		public Obj_Structure_Sink_Puddle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: watercloset.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			this.icon_state = "puddle-splash";
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			this.icon_state = "puddle";
			return null;
		}

		// Function from file: watercloset.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			this.icon_state = "puddle-splash";
			base.attack_hand( (object)(a), b, c );
			this.icon_state = "puddle";
			return null;
		}

	}

}