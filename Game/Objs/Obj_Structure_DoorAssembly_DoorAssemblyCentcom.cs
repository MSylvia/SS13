// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DoorAssembly_DoorAssemblyCentcom : Obj_Structure_DoorAssembly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.typetext = "centcom";
			this.overlays_file = "icons/obj/doors/airlocks/centcom/overlays.dmi";
			this.icontext = "ele";
			this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Centcom);
			this.anchored = 1;
			this.state = 1;
			this.icon = "icons/obj/doors/airlocks/centcom/centcom.dmi";
		}

		public Obj_Structure_DoorAssembly_DoorAssemblyCentcom ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}