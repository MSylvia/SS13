// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Server_Presets_Common : Obj_Machinery_Telecomms_Server_Presets {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Common Server";
			this.freq_listening = new ByTable();
			this.autolinkers = new ByTable(new object [] { "common" });
		}

		// Function from file: server.dm
		public Obj_Machinery_Telecomms_Server_Presets_Common ( dynamic loc = null ) : base( (object)(loc) ) {
			int? i = null;

			i = null;
			i = 1441;

			while (( i ??0) < 1489) {
				this.freq_listening.Or( i );
				i += 2;
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}