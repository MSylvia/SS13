// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_Chassis_Phazon : Obj_Item_MechaParts_Chassis {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=6";
		}

		// Function from file: mecha_parts.dm
		public Obj_Item_MechaParts_Chassis_Phazon ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.construct = new Construction_Mecha_PhazonChassis( this );
			return;
		}

	}

}