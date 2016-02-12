// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Steal_Salvage : Objective_Steal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.target_category = "salvage";
		}

		public Objective_Steal_Salvage ( string text = null ) : base( text ) {
			
		}

		// Function from file: objectives.dm
		public override string format_explanation(  ) {
			return "Ransack the station and escape with " + this.steal_target.name + ".";
		}

	}

}