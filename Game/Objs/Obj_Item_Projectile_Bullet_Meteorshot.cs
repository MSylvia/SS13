// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Bullet_Meteorshot : Obj_Item_Projectile_Bullet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 30;
			this.weaken = 8;
			this.stun = 8;
			this.hitsound = "sound/effects/meteorimpact.ogg";
			this.icon = "icons/obj/meteor.dmi";
			this.icon_state = "dust";
		}

		// Function from file: bullets.dm
		public Obj_Item_Projectile_Bullet_Meteorshot ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.SpinAnimation();
			return;
		}

		// Function from file: bullets.dm
		public override dynamic on_hit( Ent_Static target = null, double? blocked = null, dynamic hit_zone = null ) {
			blocked = blocked ?? 0;

			dynamic _default = null;

			Ent_Static M = null;
			dynamic throw_target = null;

			_default = base.on_hit( target, blocked, (object)(hit_zone) );

			if ( target is Ent_Dynamic ) {
				M = target;
				throw_target = GlobalFuncs.get_edge_target_turf( M, Map13.GetDistance( this, Map13.GetStepAway( M, this, null ) ) );
				((dynamic)M).throw_at( throw_target, 3, 2 );
			}
			return _default;
		}

	}

}