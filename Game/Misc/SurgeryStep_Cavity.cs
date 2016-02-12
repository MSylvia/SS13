// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_Cavity : SurgeryStep {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.priority = 1;
		}

		// Function from file: implant.dm
		public string get_cavity( dynamic affected = null ) {
			
			dynamic _a = affected.name; // Was a switch-case, sorry for the mess.
			if ( _a=="head" ) {
				return "cranial";
			} else if ( _a=="chest" ) {
				return "thoracic";
			} else if ( _a=="groin" ) {
				return "abdominal";
			}
			return "";
		}

		// Function from file: implant.dm
		public int get_max_wclass( dynamic affected = null ) {
			
			dynamic _a = affected.name; // Was a switch-case, sorry for the mess.
			if ( _a=="head" ) {
				return 1;
			} else if ( _a=="chest" ) {
				return 3;
			} else if ( _a=="groin" ) {
				return 2;
			}
			return 0;
		}

		// Function from file: implant.dm
		public override int can_use( dynamic user = null, dynamic target = null, string target_zone = null, Obj_Item tool = null ) {
			Organ_External affected = null;

			affected = ((Mob_Living_Carbon_Human)target).get_organ( target_zone );
			return ( affected.open == ( Lang13.Bool( affected.encased ) ? 3 : 2 ) || ( !Lang13.Bool( affected.encased ) ? Lang13.Bool( target.species.flags & 32768 ) : false ) ) && !( ( affected.status & 8 ) != 0 ) ?1:0;
		}

	}

}