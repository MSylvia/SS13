// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Bus_PresetThree : Obj_Machinery_Telecomms_Bus {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Bus 3";
			this.network = "tcommsat";
			this.freq_listening = new ByTable(new object [] { 1359, 1353 });
			this.autolinkers = new ByTable(new object [] { "processor3", "security", "command" });
		}

		public Obj_Machinery_Telecomms_Bus_PresetThree ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}