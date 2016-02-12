// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Humanoid : Mob_Living_SimpleAnimal_Hostile {

		public Type corpse = typeof(Obj_Effect_Landmark_Corpse);
		public ByTable items_to_drop = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.turns_per_move = 5;
			this.speed = -1;
			this.harm_intent_damage = 5;
			this.melee_damage_lower = 15;
			this.melee_damage_upper = 15;
			this.attacktext = "punches";
			this.a_intent = "hurt";
			this.unsuitable_atoms_damage = 15;
			this.status_flags = 8;
		}

		public Mob_Living_SimpleAnimal_Hostile_Humanoid ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: _humanoid.dm
		public override void Die( bool? gore = null ) {
			dynamic _object = null;
			dynamic A = null;

			base.Die( gore );

			if ( this.corpse != null ) {
				Lang13.Call( this.corpse, this.loc );
			}

			if ( this.items_to_drop.len != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.items_to_drop )) {
					_object = _a;
					

					if ( _object is Type ) {
						Lang13.Call( _object, GlobalFuncs.get_turf( this ) );
					} else if ( _object is Ent_Dynamic ) {
						A = _object;
						((Ent_Dynamic)A).forceMove( GlobalFuncs.get_turf( this ) );
					}
				}
			}
			GlobalFuncs.qdel( this );
			return;
		}

	}

}