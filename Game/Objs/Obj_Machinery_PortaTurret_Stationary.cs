// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_PortaTurret_Stationary : Obj_Machinery_PortaTurret {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.emagged = 1;
		}

		// Function from file: portable_turret.dm
		public Obj_Machinery_PortaTurret_Stationary ( dynamic loc = null ) : base( (object)(loc) ) {
			this.installation = new Obj_Item_Weapon_Gun_Energy_Laser( this.loc );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}