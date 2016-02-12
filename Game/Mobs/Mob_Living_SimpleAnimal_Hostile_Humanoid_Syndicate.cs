// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Humanoid_Syndicate : Mob_Living_SimpleAnimal_Hostile_Humanoid {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "syndicate";
			this.icon_dead = "syndicate_dead";
			this.icon_gib = "syndicate_gib";
			this.melee_damage_lower = 10;
			this.melee_damage_upper = 10;
			this.corpse = typeof(Obj_Effect_Landmark_Corpse_Syndicatesoldier);
			this.faction = "syndicate";
			this.icon_state = "syndicate";
		}

		public Mob_Living_SimpleAnimal_Hostile_Humanoid_Syndicate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: syndicate.dm
		public override bool CanAttack( dynamic target = null ) {
			dynamic M = null;

			
			if ( target is Mob ) {
				M = target;

				if ( GlobalVars.ticker.mode.syndicates.Contains( M.mind ) ) {
					return false;
				}
			}
			return base.CanAttack( (object)(target) );
		}

	}

}