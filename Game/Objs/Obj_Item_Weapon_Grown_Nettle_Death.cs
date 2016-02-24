// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grown_Nettle_Death : Obj_Item_Weapon_Grown_Nettle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Deathnettleseed);
			this.force = 30;
			this.throwforce = 15;
			this.origin_tech = "combat=3";
			this.icon_state = "deathnettle";
		}

		public Obj_Item_Weapon_Grown_Nettle_Death ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: growninedible.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			
			if ( !base.attack( (object)(M), (object)(user), def_zone ) ) {
				return false;
			}

			if ( M is Mob_Living ) {
				M.WriteMsg( "<span class='danger'>You are stunned by the powerful acid of the Deathnettle!</span>" );
				GlobalFuncs.add_logs( user, M, "attacked", this );
				((Mob)M).adjust_blurriness( this.force / 7 );

				if ( Rand13.PercentChance( 20 ) ) {
					((Mob)M).Paralyse( this.force / 6 );
					((Mob)M).Weaken( this.force / 15 );
				}
				M.drop_item();
			}
			return false;
		}

		// Function from file: growninedible.dm
		public override bool pickup( dynamic user = null ) {
			
			if ( base.pickup( (object)(user) ) ) {
				
				if ( Rand13.PercentChance( 50 ) ) {
					((Mob)user).Paralyse( 5 );
					user.WriteMsg( "<span class='userdanger'>You are stunned by the Deathnettle when you try picking it up!</span>" );
				}
			}
			return false;
		}

		// Function from file: growninedible.dm
		public override bool add_juice(  ) {
			base.add_juice();
			this.reagents.add_reagent( "facid", Num13.Round( ( this.potency ??0) / 2, 1 ) );
			this.force = Num13.Round( ( this.potency ??0) / 2.5 + 5, 1 );
			return false;
		}

	}

}