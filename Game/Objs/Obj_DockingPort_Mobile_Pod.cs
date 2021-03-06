// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_DockingPort_Mobile_Pod : Obj_DockingPort_Mobile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "pod";
			this.dwidth = 1;
			this.width = 3;
			this.height = 4;
			this.launch_status = 0;
		}

		// Function from file: emergency.dm
		public Obj_DockingPort_Mobile_Pod ( dynamic loc = null ) : base( (object)(loc) ) {
			
			if ( this.id == "pod" ) {
				GlobalFuncs.warning( "" + ( "" + this.type + " id has not been changed from the default. Use the id convention \"pod1\" \"pod2\" etc." ) + " in " + "code/modules/shuttle/emergency.dm" + " at line " + 251 + " src: " + this + " usr: " + Task13.User + "." );
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: emergency.dm
		public override void cancel( dynamic signalOrigin = null ) {
			return;
		}

		// Function from file: emergency.dm
		public override int request( Obj_DockingPort_Stationary S = null, double? coefficient = null, dynamic signalOrigin = null, string reason = null, bool? redAlert = null ) {
			
			if ( ( GlobalVars.security_level == 2 || GlobalVars.security_level == 3 ) && this.launch_status == 0 ) {
				this.launch_status = 2;
				return base.request( S, coefficient, (object)(signalOrigin), reason, redAlert );
			}
			return 0;
		}

	}

}