// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Ion_Weak : Obj_Item_Projectile_Ion {

		public Obj_Item_Projectile_Ion_Weak ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: special.dm
		public override dynamic on_hit( Ent_Static target = null, double? blocked = null, dynamic hit_zone = null ) {
			blocked = blocked ?? 0;

			base.on_hit( target, blocked, (object)(hit_zone) );
			GlobalFuncs.empulse( target, 0, 0 );
			return 1;
		}

	}

}