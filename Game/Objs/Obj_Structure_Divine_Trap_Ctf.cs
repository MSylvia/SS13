// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Divine_Trap_Ctf : Obj_Structure_Divine_Trap {

		public string team = "white";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.alpha = 255;
			this.health = Double.PositiveInfinity;
			this.maxhealth = Double.PositiveInfinity;
			this.time_between_triggers = 1;
		}

		public Obj_Structure_Divine_Trap_Ctf ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: capture_the_flag.dm
		public override void trap_effect( Ent_Dynamic L = null ) {
			
			if ( !Lang13.Bool( ((dynamic)L).faction.Contains( this.team ) ) ) {
				((dynamic)L).WriteMsg( "<span class='danger'><B>Stay out of the enemy spawn!</B></span>" );
				((dynamic)L).dust();
			}
			return;
		}

	}

}