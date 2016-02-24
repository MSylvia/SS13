// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Asteroid_FuguGland : Obj_Item_Asteroid {

		public dynamic banned_mobs = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 4;
			this.origin_tech = "biotech=6";
			this.icon = "icons/obj/surgery.dmi";
			this.icon_state = "fugu_gland";
			this.layer = 4;
		}

		public Obj_Item_Asteroid_FuguGland ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mining_mobs.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic A = null;

			
			if ( proximity_flag == true && target is Mob_Living_SimpleAnimal ) {
				A = target;

				if ( A.buffed != 0 || Lang13.Bool( this.banned_mobs.Contains( A.type ) ) || Lang13.Bool( A.stat ) ) {
					user.WriteMsg( "<span class='warning'>Something's interfering with the " + this + "'s effects. It's no use.</span>" );
					return false;
				}
				A.buffed++;
				A.maxHealth *= 1.5;
				A.health = Num13.MinInt( Convert.ToInt32( A.maxHealth ), Convert.ToInt32( A.health * 1.5 ) );
				A.melee_damage_lower = Num13.MaxInt( Convert.ToInt32( A.melee_damage_lower * 2 ), 10 );
				A.melee_damage_upper = Num13.MaxInt( Convert.ToInt32( A.melee_damage_upper * 2 ), 10 );
				A.transform *= 2;
				A.environment_smash += 2;
				user.WriteMsg( "<span class='info'>You increase the size of " + A + ", giving it a surge of strength!</span>" );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

	}

}