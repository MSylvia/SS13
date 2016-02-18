// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Symptom_Fever : Symptom {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Fever";
			this.resistance = 3;
			this.stage_speed = 3;
			this.transmittable = 2;
			this.level = 2;
			this.severity = 2;
		}

		// Function from file: fever.dm
		public override void Activate( Disease_Advance A = null ) {
			dynamic M = null;

			base.Activate( A );

			if ( Rand13.PercentChance( GlobalVars.SYMPTOM_ACTIVATION_PROB ) ) {
				M = A.affected_mob;
				M.WriteMsg( "<span class='warning'>" + Rand13.Pick(new object [] { "You feel hot.", "You feel like you're burning." }) + "</span>" );

				if ( Convert.ToDouble( M.bodytemperature ) < 360.41 ) {
					M.bodytemperature = Num13.MinInt( Convert.ToInt32( M.bodytemperature + ( A.stage ??0) * 20 ), ((int)( 359.41 )) );
				}
			}
			return;
		}

	}

}