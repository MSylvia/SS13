// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Revolver_Golden : Obj_Item_Weapon_Gun_Projectile_Revolver {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.fire_sound = "sound/weapons/resonator_blast.ogg";
			this.recoil = 8;
			this.pin = typeof(Obj_Item_Device_FiringPin);
			this.icon_state = "goldrevolver";
		}

		public Obj_Item_Weapon_Gun_Projectile_Revolver_Golden ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}