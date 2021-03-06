// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Cow : Mob_Living_SimpleAnimal {

		public Obj_Udder udder = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "cow";
			this.icon_dead = "cow_dead";
			this.icon_gib = "cow_gib";
			this.speak = new ByTable(new object [] { "moo?", "moo", "MOOOOOO" });
			this.speak_emote = new ByTable(new object [] { "moos", "moos hauntingly" });
			this.emote_hear = new ByTable(new object [] { "brays." });
			this.emote_see = new ByTable(new object [] { "shakes its head." });
			this.speak_chance = 1;
			this.turns_per_move = 5;
			this.butcher_results = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab), 6 );
			this.response_help = "pets";
			this.response_disarm = "gently pushes aside";
			this.response_harm = "kicks";
			this.attacktext = "kicks";
			this.attack_sound = "sound/weapons/punch1.ogg";
			this.health = 50;
			this.gold_core_spawnable = 2;
			this.icon_state = "cow";
			this.see_in_dark = 6;
		}

		// Function from file: farm_animals.dm
		public Mob_Living_SimpleAnimal_Cow ( dynamic loc = null ) : base( (object)(loc) ) {
			this.udder = new Obj_Udder();
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: farm_animals.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			ByTable responses = null;

			
			if ( !( this.stat != 0 ) && a.a_intent == "disarm" && this.icon_state != this.icon_dead ) {
				((Ent_Static)a).visible_message( "<span class='warning'>" + a + " tips over " + this + ".</span>", "<span class='notice'>You tip over " + this + ".</span>" );
				this.Weaken( 30 );
				this.icon_state = this.icon_dead;
				Task13.Schedule( Rand13.Int( 20, 50 ), (Task13.Closure)(() => {
					
					if ( !( this.stat != 0 ) && Lang13.Bool( a ) ) {
						this.icon_state = this.icon_living;
						responses = new ByTable(new object [] { 
							"" + this + " looks at you imploringly.", 
							"" + this + " looks at you pleadingly", 
							"" + this + " looks at you with a resigned expression.", 
							"" + this + " seems resigned to its fate."
						 });
						a.WriteMsg( Rand13.PickFromTable( responses ) );
					}
					return;
				}));
			} else {
				base.attack_hand( (object)(a), b, c );
			}
			return null;
		}

		// Function from file: farm_animals.dm
		public override bool Life(  ) {
			bool _default = false;

			_default = base.Life();

			if ( this.stat == 0 ) {
				this.udder.generateMilk();
			}
			return _default;
		}

		// Function from file: farm_animals.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( this.stat == 0 && A is Obj_Item_Weapon_ReagentContainers_Glass ) {
				this.udder.milkAnimal( A, user );
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: farm_animals.dm
		public override dynamic Destroy(  ) {
			GlobalFuncs.qdel( this.udder );
			this.udder = null;
			return base.Destroy();
		}

	}

}