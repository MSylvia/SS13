// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Assembly_Signaler_Reciever : Obj_Item_Device_Assembly_Signaler {

		public bool on = false;

		public Obj_Item_Device_Assembly_Signaler_Reciever ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: signaler.dm
		public override bool receive_signal( Signal signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			
			if ( !this.on ) {
				return false;
			}
			return base.receive_signal( signal, receive_method, (object)(receive_param) );
		}

		// Function from file: signaler.dm
		public override string describe(  ) {
			return "The radio receiver is " + ( this.on ? "on" : "off" ) + ".";
		}

		// Function from file: signaler.dm
		public override bool activate(  ) {
			this.toggle_safety();
			return true;
		}

		// Function from file: signaler.dm
		public void toggle_safety(  ) {
			this.on = !this.on;
			return;
		}

	}

}