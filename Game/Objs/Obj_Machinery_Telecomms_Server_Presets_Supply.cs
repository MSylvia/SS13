// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Server_Presets_Supply : Obj_Machinery_Telecomms_Server_Presets {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Supply Server";
			this.freq_listening = new ByTable(new object [] { 1347 });
			this.autolinkers = new ByTable(new object [] { "supply" });
		}

		public Obj_Machinery_Telecomms_Server_Presets_Supply ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}