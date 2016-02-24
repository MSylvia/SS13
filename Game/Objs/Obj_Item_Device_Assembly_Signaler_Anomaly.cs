// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Assembly_Signaler_Anomaly : Obj_Item_Device_Assembly_Signaler {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "electronic";
			this.icon_state = "anomaly core";
		}

		public Obj_Item_Device_Assembly_Signaler_Anomaly ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tgstation.dme
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			return null;
		}

		// Function from file: signaler.dm
		public override bool receive_signal( Signal signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			Obj_Effect_Anomaly A = null;

			
			if ( !( signal != null ) ) {
				return false;
			}

			if ( signal.encryption != this.code ) {
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( this ), typeof(Obj_Effect_Anomaly) )) {
				A = _a;
				
				A.anomalyNeutralize();
			}
			return false;
		}

	}

}