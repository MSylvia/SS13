// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Components_Binary_Valve : Obj_Machinery_Atmospherics_Components_Binary {

		public bool frequency = false;
		public dynamic id = null;
		public bool open = false;
		public string valve_type = "m";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.can_unwrench = true;
			this.icon_state = "mvalve_map";
		}

		public Obj_Machinery_Atmospherics_Components_Binary_Valve ( dynamic loc = null, int? process = null ) : base( (object)(loc), process ) {
			
		}

		// Function from file: valve.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			this.add_fingerprint( Task13.User );
			this.update_icon_nopipes( true );
			Task13.Sleep( 10 );

			if ( this.open ) {
				this.close();
				return null;
			}
			this.f_open();
			return null;
		}

		// Function from file: valve.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return null;
		}

		// Function from file: valve.dm
		public void normalize_dir(  ) {
			
			if ( this.dir == GlobalVars.SOUTH ) {
				this.dir = ((int)( GlobalVars.NORTH ));
			} else if ( this.dir == GlobalVars.WEST ) {
				this.dir = ((int)( GlobalVars.EAST ));
			}
			return;
		}

		// Function from file: valve.dm
		public void close(  ) {
			this.open = false;
			this.update_icon_nopipes();
			this.investigate_log( "was closed by " + ( Task13.User != null ? GlobalFuncs.key_name( Task13.User ) : "a remote signal" ), "atmos" );
			return;
		}

		// Function from file: valve.dm
		[VerbInfo( name: "open" )]
		public void f_open(  ) {
			Pipeline parent1 = null;

			this.open = true;
			this.update_icon_nopipes();
			this.update_parents();
			parent1 = this.parents[1];
			parent1.reconcile_air();
			this.investigate_log( "was opened by " + ( Task13.User != null ? GlobalFuncs.key_name( Task13.User ) : "a remote signal" ), "atmos" );
			return;
		}

		// Function from file: valve.dm
		public override void update_icon_nopipes( bool? animation = null ) {
			animation = animation ?? false;

			this.normalize_dir();

			if ( animation == true ) {
				Icon13.Flick( "" + this.valve_type + "valve_" + this.open + !this.open, this );
			}
			this.icon_state = "" + this.valve_type + "valve_" + ( this.open ? "on" : "off" );
			return;
		}

	}

}