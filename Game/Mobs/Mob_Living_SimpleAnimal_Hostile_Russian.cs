// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Russian : Mob_Living_SimpleAnimal_Hostile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "russianmelee";
			this.icon_dead = "russianmelee_dead";
			this.icon_gib = "syndicate_gib";
			this.turns_per_move = 5;
			this.speed = 0;
			this.harm_intent_damage = 5;
			this.melee_damage_lower = 15;
			this.melee_damage_upper = 15;
			this.attacktext = "punches";
			this.attack_sound = "sound/weapons/punch1.ogg";
			this.a_intent = "harm";
			this.loot = new ByTable(new object [] { typeof(Obj_Effect_Landmark_Mobcorpse_Russian), typeof(Obj_Item_Weapon_Kitchen_Knife) });
			this.atmos_requirements = new ByTable().Set( "min_oxy", 5 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 1 ).Set( "min_co2", 0 ).Set( "max_co2", 5 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.unsuitable_atmos_damage = 15;
			this.faction = new ByTable(new object [] { "russian" });
			this.del_on_death = true;
			this.icon_state = "russianmelee";
		}

		public Mob_Living_SimpleAnimal_Hostile_Russian ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}