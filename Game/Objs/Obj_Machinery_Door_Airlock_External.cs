// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Airlock_External : Obj_Machinery_Door_Airlock {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.overlays_file = "icons/obj/doors/airlocks/external/overlays.dmi";
			this.doortype = typeof(Obj_Structure_DoorAssembly_DoorAssemblyExt);
			this.icon = "icons/obj/doors/airlocks/external/external.dmi";
		}

		public Obj_Machinery_Door_Airlock_External ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}