// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_PortableAtmospherics_Canister_Nitrogen : Obj_Machinery_PortableAtmospherics_Canister {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.gas_type = "n2";
			this.icon_state = "red";
		}

		public Obj_Machinery_PortableAtmospherics_Canister_Nitrogen ( dynamic loc = null, GasMixture existing_mixture = null ) : base( (object)(loc), existing_mixture ) {
			
		}

	}

}