// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Melee_TouchAttack_Disintegrate : Obj_Item_Weapon_Melee_TouchAttack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.catchphrase = "EI NATH!!";
			this.on_use_sound = "sound/magic/Disintegrate.ogg";
			this.item_state = "disintegrate";
			this.icon_state = "disintegrate";
		}

		public Obj_Item_Weapon_Melee_TouchAttack_Disintegrate ( dynamic spell = null ) : base( (object)(spell) ) {
			
		}

		// Function from file: godhand.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic M = null;
			dynamic C_target = null;
			dynamic B = null;
			EffectSystem_SparkSpread sparks = null;

			
			if ( !( proximity_flag == true ) || target == user || !( target is Mob ) || !( user is Mob_Living_Carbon ) || Lang13.Bool( user.lying ) || Lang13.Bool( user.handcuffed ) ) {
				return false;
			}
			M = target;

			if ( M is Mob_Living_Carbon_Human || M is Mob_Living_Carbon_Monkey ) {
				C_target = M;
				B = ((Mob)C_target).getorgan( typeof(Obj_Item_Organ_Internal_Brain) );

				if ( Lang13.Bool( B ) ) {
					B.loc = GlobalFuncs.get_turf( C_target );
					((Obj_Item_Organ_Internal_Brain)B).transfer_identity( C_target );
					C_target.internal_organs.Remove( B );
				}
			}
			sparks = new EffectSystem_SparkSpread();
			sparks.set_up( 4, 0, M.loc );
			sparks.start();
			((Mob)M).gib();
			base.afterattack( (object)(target), (object)(user), proximity_flag, click_parameters );
			return false;
		}

	}

}