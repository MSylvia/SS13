// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Bus_PresetFour : Obj_Machinery_Telecomms_Bus {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Bus 4";
			this.network = "tcommsat";
			this.freq_listening = new ByTable(new object [] { 1357 });
			this.autolinkers = new ByTable(new object [] { "processor4", "engineering", "common" });
		}

		// Function from file: bus.dm
		public Obj_Machinery_Telecomms_Bus_PresetFour ( dynamic loc = null ) : base( (object)(loc) ) {
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