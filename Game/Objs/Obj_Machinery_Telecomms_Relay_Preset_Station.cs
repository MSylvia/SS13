// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Relay_Preset_Station : Obj_Machinery_Telecomms_Relay_Preset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Station Relay";
			this.listening_level = 1;
			this.autolinkers = new ByTable(new object [] { "s_relay" });
		}

		public Obj_Machinery_Telecomms_Relay_Preset_Station ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}