// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Swarmer_Destructible_Trap : Obj_Effect_Swarmer_Destructible {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 10;
			this.icon_state = "trap";
		}

		public Obj_Effect_Swarmer_Destructible_Trap ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: swarmer.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Ent_Dynamic L = null;

			
			if ( O is Mob_Living ) {
				L = O;

				if ( !( L is Mob_Living_SimpleAnimal_Hostile_Swarmer ) ) {
					GlobalFuncs.playsound( this.loc, "sound/effects/snap.ogg", 50, 1, -1 );
					((dynamic)L).electrocute_act( 0, this, 1, 1 );

					if ( L is Mob_Living_Silicon_Robot ) {
						((dynamic)L).Weaken( 5 );
					}
					GlobalFuncs.qdel( this );
				}
			}
			base.Crossed( O, (object)(X) );
			return null;
		}

	}

}