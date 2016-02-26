// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Guardiancreator : Obj_Item_Weapon {

		public int? used = 0;
		public string theme = "magic";
		public string mob_name = "Guardian Spirit";
		public string use_message = "You shuffle the deck...";
		public string used_message = "All the cards seem to be blank now.";
		public string failure_message = "..And draw a card! It's...blank? Maybe you should try again later.";
		public string ling_failure = "The deck refuses to respond to a souless creature such as you.";
		public ByTable possible_guardians = new ByTable(new object [] { "Chaos", "Standard", "Ranged", "Support", "Explosive" });
		public bool random = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/toy.dmi";
			this.icon_state = "deck_syndicate_full";
		}

		public Obj_Item_Weapon_Guardiancreator ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: guardian.dm
		public void spawn_guardian( dynamic user = null, dynamic key = null ) {
			dynamic gaurdiantype = null;
			Type pickedtype = null;
			dynamic G = null;
			dynamic colour = null;
			dynamic picked_name = null;

			gaurdiantype = "Standard";

			if ( this.random ) {
				gaurdiantype = Rand13.PickFromTable( this.possible_guardians );
			} else {
				gaurdiantype = Interface13.Input( user, "Pick the type of " + this.mob_name, "" + this.mob_name + " Creation", null, this.possible_guardians, InputType.Null | InputType.Any );
			}
			pickedtype = typeof(Mob_Living_SimpleAnimal_Hostile_Guardian_Punch);

			dynamic _a = gaurdiantype; // Was a switch-case, sorry for the mess.
			if ( _a=="Chaos" ) {
				pickedtype = typeof(Mob_Living_SimpleAnimal_Hostile_Guardian_Fire);
			} else if ( _a=="Standard" ) {
				pickedtype = typeof(Mob_Living_SimpleAnimal_Hostile_Guardian_Punch);
			} else if ( _a=="Ranged" ) {
				pickedtype = typeof(Mob_Living_SimpleAnimal_Hostile_Guardian_Ranged);
			} else if ( _a=="Support" ) {
				pickedtype = typeof(Mob_Living_SimpleAnimal_Hostile_Guardian_Healer);
			} else if ( _a=="Explosive" ) {
				pickedtype = typeof(Mob_Living_SimpleAnimal_Hostile_Guardian_Bomb);
			}
			G = Lang13.Call( pickedtype, user );
			G.summoner = user;
			G.key = key;
			G.WriteMsg( "You are a " + this.mob_name + " bound to serve " + user.real_name + "." );
			G.WriteMsg( "You are capable of manifesting or recalling to your master with the buttons on your HUD. You will also find a button to communicate with them privately there." );
			G.WriteMsg( "While personally invincible, you will die if " + user.real_name + " does, and any damage dealt to you will have a portion passed on to them as you feed upon them to sustain yourself." );
			G.WriteMsg( "" + G.playstyle_string );
			G.faction = user.faction;
			user.verbs += typeof(Mob_Living).GetMethod( "guardian_comm" );
			user.verbs += typeof(Mob_Living).GetMethod( "guardian_recall" );
			user.verbs += typeof(Mob_Living).GetMethod( "guardian_reset" );
			colour = null;
			picked_name = null;

			switch ((string)( this.theme )) {
				case "magic":
					user.WriteMsg( "" + G.magic_fluff_string + "." );
					colour = Rand13.Pick(new object [] { "Pink", "Red", "Orange", "Green", "Blue" });
					picked_name = Rand13.Pick(new object [] { "Aries", "Leo", "Sagittarius", "Taurus", "Virgo", "Capricorn", "Gemini", "Libra", "Aquarius", "Cancer", "Scorpio", "Pisces" });
					break;
				case "tech":
					user.WriteMsg( "" + G.tech_fluff_string + "." );
					G.bubble_icon = "holo";
					colour = Rand13.Pick(new object [] { "Rose", "Peony", "Lily", "Daisy", "Zinnia", "Ivy", "Iris", "Petunia", "Violet", "Lilac", "Orchid" });
					picked_name = Rand13.Pick(new object [] { "Gallium", "Indium", "Thallium", "Bismuth", "Aluminium", "Mercury", "Iron", "Silver", "Zinc", "Titanium", "Chromium", "Nickel", "Platinum", "Tellurium", "Palladium", "Rhodium", "Cobalt", "Osmium", "Tungsten", "Iridium" });
					break;
			}
			G.name = "" + picked_name + " " + colour;
			G.real_name = "" + picked_name + " " + colour;
			G.icon_living = "" + this.theme + colour;
			G.icon_state = "" + this.theme + colour;
			G.icon_dead = "" + this.theme + colour;
			G.mind.name = "" + G.real_name;
			return;
		}

		// Function from file: guardian.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Mob_Living_SimpleAnimal_Hostile_Guardian G = null;
			ByTable candidates = null;
			dynamic theghost = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.living_mob_list, typeof(Mob_Living_SimpleAnimal_Hostile_Guardian) )) {
				G = _a;
				

				if ( G.summoner == user ) {
					user.WriteMsg( "You already have a " + this.mob_name + "!" );
					return null;
				}
			}

			if ( Lang13.Bool( user.mind ) && user.mind.changeling != null ) {
				user.WriteMsg( "" + this.ling_failure );
				return null;
			}

			if ( this.used == GlobalVars.TRUE ) {
				user.WriteMsg( "" + this.used_message );
				return null;
			}
			this.used = GlobalVars.TRUE;
			user.WriteMsg( "" + this.use_message );
			candidates = GlobalFuncs.pollCandidates( "Do you want to play as the " + this.mob_name + " of " + user.real_name + "?", "pAI", null, GlobalVars.FALSE, 100 );
			theghost = null;

			if ( candidates.len != 0 ) {
				theghost = Rand13.PickFromTable( candidates );
				this.spawn_guardian( user, theghost.key );
			} else {
				user.WriteMsg( "" + this.failure_message );
				this.used = GlobalVars.FALSE;
			}
			return null;
		}

	}

}