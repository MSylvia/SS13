// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Server_Presets_Medical : Obj_Machinery_Telecomms_Server_Presets {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Medical Server";
			this.freq_listening = new ByTable(new object [] { 1355 });
			this.autolinkers = new ByTable(new object [] { "medical" });
		}

		public Obj_Machinery_Telecomms_Server_Presets_Medical ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}