// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DoorAssembly_DoorAssemblyHighsecurity : Obj_Structure_DoorAssembly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.overlays_file = "icons/obj/doors/airlocks/highsec/overlays.dmi";
			this.typetext = "highsecurity";
			this.icontext = "highsec";
			this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Highsecurity);
			this.anchored = 1;
			this.state = 1;
			this.icon = "icons/obj/doors/airlocks/highsec/highsec.dmi";
		}

		public Obj_Structure_DoorAssembly_DoorAssemblyHighsecurity ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}