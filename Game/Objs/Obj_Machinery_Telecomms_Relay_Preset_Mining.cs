// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Relay_Preset_Mining : Obj_Machinery_Telecomms_Relay_Preset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Mining Relay";
			this.autolinkers = new ByTable(new object [] { "m_relay" });
		}

		public Obj_Machinery_Telecomms_Relay_Preset_Mining ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}