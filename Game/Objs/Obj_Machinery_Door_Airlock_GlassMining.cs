// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Airlock_GlassMining : Obj_Machinery_Door_Airlock {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.doortype = typeof(Obj_Structure_DoorAssembly_DoorAssemblyMin_Glass);
			this.glass = true;
			this.icon = "icons/obj/doors/airlocks/station/mining.dmi";
		}

		public Obj_Machinery_Door_Airlock_GlassMining ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}