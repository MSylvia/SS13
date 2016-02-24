// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Meteor_Tunguska : Obj_Effect_Meteor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.hits = 30;
			this.hitpwr = 1;
			this.heavy = true;
			this.meteorsound = "sound/effects/bamf.ogg";
			this.meteordrop = typeof(Obj_Item_Weapon_Ore_Plasma);
			this.icon_state = "flaming";
		}

		public Obj_Effect_Meteor_Tunguska ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: meteors.dm
		public override dynamic Bump( Ent_Static Obstacle = null, dynamic yes = null ) {
			base.Bump( Obstacle, (object)(yes) );

			if ( Rand13.PercentChance( 20 ) ) {
				GlobalFuncs.explosion( this.loc, 2, 4, 6, 8 );
			}
			return null;
		}

		// Function from file: meteors.dm
		public override void meteor_effect( bool? sound = null ) {
			base.meteor_effect( this.heavy );
			GlobalFuncs.explosion( this.loc, 5, 10, 15, 20, 0 );
			return;
		}

	}

}