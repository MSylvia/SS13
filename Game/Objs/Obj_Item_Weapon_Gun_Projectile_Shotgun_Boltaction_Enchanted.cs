// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Shotgun_Boltaction_Enchanted : Obj_Item_Weapon_Gun_Projectile_Shotgun_Boltaction {

		public int guns_left = 30;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mag_type = typeof(Obj_Item_AmmoBox_Magazine_Internal_Boltaction_Enchanted);
		}

		// Function from file: shotgun.dm
		public Obj_Item_Weapon_Gun_Projectile_Shotgun_Boltaction_Enchanted ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.bolt_open = true;
			this.pump();
			return;
		}

		// Function from file: shotgun.dm
		public override void shoot_live_shot( dynamic user = null, bool? pointblank = null, dynamic pbtarget = null, bool? message = null ) {
			pointblank = pointblank ?? false;
			message = message ?? true;

			Obj_Item_Weapon_Gun_Projectile_Shotgun_Boltaction_Enchanted GUN = null;

			base.shoot_live_shot( (object)(user), pointblank, (object)(pbtarget), message );

			if ( this.guns_left != 0 ) {
				GUN = new Obj_Item_Weapon_Gun_Projectile_Shotgun_Boltaction_Enchanted();
				GUN.guns_left = this.guns_left - 1;
				user.drop_item();
				((Mob)user).swap_hand();
				((Mob)user).put_in_hands( GUN );
			} else {
				user.drop_item();
			}
			this.throw_at_fast( Rand13.PickFromTable( Map13.FetchInViewExcludeThis( GlobalFuncs.get_turf( user ), 7 ) ), 1, 1 );
			((Ent_Static)user).visible_message( "<span class='warning'>" + user + " tosses aside the spent rifle!</span>" );
			return;
		}

		// Function from file: shotgun.dm
		public override bool dropped( dynamic user = null ) {
			this.guns_left = 0;
			return false;
		}

	}

}