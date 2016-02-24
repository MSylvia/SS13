// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Beam_Wormhole : Obj_Item_Projectile_Beam {

		public Obj_Item_Weapon_Gun_Energy_WormholeProjector gun = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.color = "#33CCFF";
			this.hitsound = "sparks";
			this.damage = 3;
			this.icon_state = "spark";
		}

		// Function from file: special.dm
		public Obj_Item_Projectile_Beam_Wormhole ( dynamic casing = null ) : base( (object)(casing) ) {
			
			if ( Lang13.Bool( casing ) ) {
				this.gun = casing.gun;
			}
			return;
		}

		// Function from file: special.dm
		public override dynamic on_hit( Ent_Static target = null, double? blocked = null, dynamic hit_zone = null ) {
			dynamic portal_destination = null;

			
			if ( target is Mob ) {
				portal_destination = Rand13.PickFromTable( Map13.FetchInRangeExcludeThis( this, 6 ) );
				GlobalFuncs.do_teleport( target, portal_destination );
				return base.on_hit( target, blocked, (object)(hit_zone) );
			}

			if ( !( this.gun != null ) ) {
				GlobalFuncs.qdel( this );
			}
			this.gun.create_portal( this );
			return null;
		}

	}

}