// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DoorAssembly_DoorAssemblyMed : Obj_Structure_DoorAssembly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.base_icon_state = "med";
			this.base_name = "Medical Airlock";
			this.glass_type = "/glass_medical";
			this.airlock_type = "/medical";
		}

		public Obj_Structure_DoorAssembly_DoorAssemblyMed ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}