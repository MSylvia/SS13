// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Alien_Sentinel : Mob_Living_SimpleAnimal_Hostile_Alien {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "aliens_running";
			this.icon_dead = "aliens_dead";
			this.health = 120;
			this.melee_damage_lower = 15;
			this.melee_damage_upper = 15;
			this.ranged = true;
			this.projectiletype = typeof(Obj_Item_Projectile_Neurotox);
			this.projectilesound = "sound/weapons/pierce.ogg";
			this.icon_state = "aliens_running";
		}

		public Mob_Living_SimpleAnimal_Hostile_Alien_Sentinel ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}