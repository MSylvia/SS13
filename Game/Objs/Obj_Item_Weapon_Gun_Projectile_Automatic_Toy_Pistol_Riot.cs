// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Automatic_Toy_Pistol_Riot : Obj_Item_Weapon_Gun_Projectile_Automatic_Toy_Pistol {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mag_type = typeof(Obj_Item_AmmoBox_Magazine_Toy_Pistol_Riot);
		}

		// Function from file: toy.dm
		public Obj_Item_Weapon_Gun_Projectile_Automatic_Toy_Pistol_Riot ( dynamic loc = null ) : base( (object)(loc) ) {
			this.magazine = new Obj_Item_AmmoBox_Magazine_Toy_Pistol_Riot( this );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}