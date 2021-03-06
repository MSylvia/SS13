// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Magic_Teleport : Obj_Item_Projectile_Magic {

		public bool inner_tele_radius = false;
		public int outer_tele_radius = 6;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "bluespace";
		}

		public Obj_Item_Projectile_Magic_Teleport ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: magic.dm
		public override dynamic on_hit( Ent_Static target = null, double? blocked = null, dynamic hit_zone = null ) {
			dynamic _default = null;

			int teleammount = 0;
			Ent_Static teleloc = null;
			Ent_Dynamic stuff = null;
			EffectSystem_SmokeSpread smoke = null;

			_default = base.on_hit( target, blocked, (object)(hit_zone) );
			teleammount = 0;
			teleloc = target;

			if ( !( target is Tile ) ) {
				teleloc = target.loc;
			}

			foreach (dynamic _a in Lang13.Enumerate( teleloc, typeof(Ent_Dynamic) )) {
				stuff = _a;
				

				if ( !Lang13.Bool( stuff.anchored ) && stuff.loc != null ) {
					teleammount++;
					GlobalFuncs.do_teleport( stuff, stuff, 10 );
					smoke = new EffectSystem_SmokeSpread();
					smoke.set_up( Num13.MaxInt( Num13.Floor( 4 - teleammount ), 0 ), stuff.loc );
					smoke.start();
				}
			}
			return _default;
		}

	}

}