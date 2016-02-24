// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Upload_Borg : Obj_Machinery_Computer_Upload {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.circuit = typeof(Obj_Item_Weapon_Circuitboard_Borgupload);
		}

		public Obj_Machinery_Computer_Upload_Borg ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			
		}

		// Function from file: law.dm
		public override bool can_upload_to( dynamic S = null ) {
			
			if ( !Lang13.Bool( S ) || !( S is Mob_Living_Silicon_Robot ) ) {
				return false;
			}

			if ( S.scrambledcodes || Lang13.Bool( S.emagged ) ) {
				return false;
			}
			return base.can_upload_to( (object)(S) );
		}

		// Function from file: law.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				return null;
			}
			this.current = GlobalFuncs.select_active_free_borg( a );

			if ( !Lang13.Bool( this.current ) ) {
				a.WriteMsg( "<span class='caution'>No active unslaved cyborgs detected!</span>" );
			} else {
				a.WriteMsg( "" + this.current.name + " selected for law changes." );
			}
			return null;
		}

	}

}