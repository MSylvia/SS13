// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Shotgun_Automatic_Combat : Obj_Item_Weapon_Gun_Projectile_Shotgun_Automatic {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "combat=5;materials=2";
			this.mag_type = typeof(Obj_Item_AmmoBox_Magazine_Internal_Shot_Com);
			this.w_class = 5;
			this.icon_state = "cshotgun";
		}

		public Obj_Item_Weapon_Gun_Projectile_Shotgun_Automatic_Combat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}