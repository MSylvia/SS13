// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Tape_Random : Obj_Item_Device_Tape {

		// Function from file: taperecorder.dm
		public Obj_Item_Device_Tape_Random ( dynamic loc = null ) : base( (object)(loc) ) {
			this.icon_state = "tape_" + Rand13.Pick(new object [] { "white", "blue", "red", "yellow", "purple" });
			return;
		}

	}

}