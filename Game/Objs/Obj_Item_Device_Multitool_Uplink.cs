// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Multitool_Uplink : Obj_Item_Device_Multitool {

		// Function from file: uplink.dm
		public Obj_Item_Device_Multitool_Uplink ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.hidden_uplink = new Obj_Item_Device_Uplink( this );
			this.hidden_uplink.active = GlobalVars.TRUE;
			this.hidden_uplink.lockable = GlobalVars.FALSE;
			return;
		}

	}

}