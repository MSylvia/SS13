// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Bullet_Reusable : Obj_Item_Projectile_Bullet {

		public Type ammo_type = typeof(Obj_Item_AmmoCasing_Caseless);

		public Obj_Item_Projectile_Bullet_Reusable ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: reusable.dm
		public override void on_range(  ) {
			Obj content = null;

			
			if ( this.contents.len != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj) )) {
					content = _a;
					
					content.loc = this.loc;
				}
			} else {
				Lang13.Call( this.ammo_type, this.loc );
			}
			base.on_range();
			return;
		}

		// Function from file: reusable.dm
		public override dynamic on_hit( Ent_Static target = null, double? blocked = null, dynamic hit_zone = null ) {
			blocked = blocked ?? 0;

			dynamic _default = null;

			Obj content = null;

			_default = base.on_hit( target, blocked, (object)(hit_zone) );

			if ( this.contents.len != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj) )) {
					content = _a;
					
					content.loc = this.loc;
				}
			} else {
				Lang13.Call( this.ammo_type, this.loc );
			}
			return _default;
		}

	}

}