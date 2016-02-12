// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Bible : Obj_Item_Weapon_Storage {

		public dynamic affecting = null;
		public string deity_name = "Christ";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.throw_speed = 1;
			this.throw_range = 5;
			this.force = 2.5;
			this.attack_verb = new ByTable(new object [] { "whack", "slap", "slam" });
			this.autoignition_temperature = 522;
			this.fire_fuel = 2;
			this.icon_state = "bible";
		}

		public Obj_Item_Weapon_Storage_Bible ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: bible.dm
		public override bool pickup( Mob user = null ) {
			Mob H = null;

			
			if ( user.mind != null && user.mind.assigned_role == "Chaplain" ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class ='notice'>You feel " ).item( this.deity_name ).str( "'s holy presence as you pick up " ).the( this ).item().str( ".</span>" ).ToString() );
			}

			if ( user is Mob_Living_Carbon_Human ) {
				H = user;

				if ( ( GlobalVars.ticker.mode.vampires.Contains( H.mind ) || H.mind.vampire != null ) && H.mind.vampire.powers.Contains( 0 ) ) {
					GlobalFuncs.to_chat( H, new Txt( "<span class ='danger'>" ).item( this.deity_name ).str( "'s power channels through " ).the( this ).item().str( ". You feel extremely uneasy as you grab it!</span>" ).ToString() );
					H.mind.vampire.smitecounter += 10;
				}

				if ( Lang13.Bool( GlobalVars.ticker.mode.cult.Contains( H.mind ) ) ) {
					GlobalFuncs.to_chat( H, new Txt( "<span class ='danger'>" ).item( this.deity_name ).str( "'s power channels through " ).the( this ).item().str( ". You feel uneasy as you grab it, but Nar'Sie protects you from its influence!</span>" ).ToString() );
				}
			}
			return false;
		}

		// Function from file: bible.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "rustle", 50, 1, -5 );
			_default = base.attackby( (object)(a), (object)(b), (object)(c) );
			return _default;
		}

		// Function from file: bible.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			bool water2holy = false;

			((Mob)user).delayNextAttack( 5 );

			if ( Lang13.Bool( user.mind ) && user.mind.assigned_role == "Chaplain" ) {
				
				if ( Lang13.Bool( A.reagents ) && ((Reagents)A.reagents).has_reagent( "water" ) ) {
					((Ent_Static)user).visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " blesses " ).the( A ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You bless " ).the( A ).item().str( ".</span>" ).ToString() );
					water2holy = ((Reagents)A.reagents).get_reagent_amount( "water" );
					((Reagents)A.reagents).del_reagent( "water" );
					((Reagents)A.reagents).add_reagent( "holywater", water2holy );
				}
			}
			return false;
		}

		// Function from file: bible.dm
		public void bless_mob( dynamic user = null, dynamic H = null ) {
			dynamic sponge = null;
			Organ_External affecting = null;

			sponge = H.internal_organs_by_name["brain"];

			if ( Lang13.Bool( sponge ) && Convert.ToDouble( sponge.damage ) >= 60 ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>" ).item( H ).str( " responds to " ).the( this ).item().str( "'s blessing with drooling and an empty stare. " ).item( this.deity_name ).str( "'s teachings appear to be lost on this poor soul.</span>" ).ToString() );
				return;
			}

			if ( Rand13.PercentChance( 20 ) ) {
				((Mob_Living)H).adjustBrainLoss( 5 );
			}

			if ( Rand13.PercentChance( 50 ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( H.organs, typeof(Organ_External) )) {
					affecting = _a;
					

					if ( affecting.heal_damage( 5, 5 ) ) {
						((Mob_Living)H).UpdateDamageIcon();
					}
				}
			}
			return;
		}

		// Function from file: bible.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			bool chaplain = false;
			dynamic H = null;
			dynamic H2 = null;

			chaplain = false;

			if ( Lang13.Bool( user.mind ) && user.mind.assigned_role == "Chaplain" ) {
				chaplain = true;
			}
			M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been attacked with " + this.name + " by " + user.name + " (" + user.ckey + ")</font>" );
			user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Used the " + this.name + " to attack " + M.name + " (" + M.ckey + ")</font>" );

			if ( !( user is Mob_Living_Carbon ) ) {
				M.LAssailant = null;
			} else {
				M.LAssailant = user;
			}
			GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + user.name + " (" + user.ckey + ") attacked " + M.name + " (" + M.ckey + ") with " + this.name + " (INTENT: " + String13.ToUpper( user.a_intent ) + ")</font>" ) ) );

			if ( !Lang13.Bool( user.dexterity_check() ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>You don't have the dexterity to do this!</span>" );
				return null;
			}

			if ( !chaplain ) {
				
				if ( GlobalVars.ticker.mode.vampires.Contains( user.mind ) || user.mind.vampire != null ) {
					GlobalFuncs.to_chat( user, new Txt( "<span class='danger'>" ).item( this.deity_name ).str( " channels through " ).the( this ).item().str( " and sets you ablaze for your blasphemy!</span>" ).ToString() );
					user.fire_stacks += 5;
					((Mob_Living)user).IgniteMob();
					((Mob)user).emote( "scream", null, null, true );
					M.mind.vampire.smitecounter += 50;
				} else if ( Lang13.Bool( GlobalVars.ticker.mode.cult.Contains( user.mind ) ) ) {
					GlobalFuncs.to_chat( user, new Txt( "<span class='danger'>" ).item( this.deity_name ).str( " channels through " ).the( this ).item().str( " and sets you ablaze for your blasphemy!</span>" ).ToString() );
					user.fire_stacks += 5;
					((Mob_Living)user).IgniteMob();
					((Mob)user).emote( "scream", null, null, true );
				} else {
					base.attack( (object)(M), (object)(user), def_zone, eat_override );
				}
				return null;
			}

			if ( Lang13.Bool( user.mutations.Contains( 5 ) ) && Rand13.PercentChance( 50 ) ) {
				((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).The( this ).item().str( " slips out of " ).item( user ).str( "'s hands and hits " ).his_her_its_their().str( " head.</span>" ).ToString(), new Txt( "<span class='warning'>" ).The( this ).item().str( " slips out of your hands and hits your head.</span>" ).ToString() );
				((Mob_Living)user).apply_damage( 10, "brute", "head" );
				((Mob)user).Stun( 5 );
				return null;
			}

			if ( M == user ) {
				return null;
			}

			if ( M is Mob_Living_Carbon_Human ) {
				H = M;

				if ( H.head is Obj_Item_Clothing_Head_Helmet || H.head is Obj_Item_Clothing_Head_Hardhat || H.head is Obj_Item_Clothing_Head_Fedora || H.head is Obj_Item_Clothing_Head_Culthood ) {
					((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " " ).item( Rand13.PickFromTable( this.attack_verb ) ).str( "s " ).item( H ).str( "'s head with " ).the( this ).item().str( ", but their headgear blocks the hit.</span>" ).ToString(), new Txt( "<span class='warning'>You " ).item( Rand13.PickFromTable( this.attack_verb ) ).str( " " ).item( H ).str( "'s head with " ).the( this ).item().str( ", but their headgear blocks the blessing. Blasphemy!</span>" ).ToString() );
					return null;
				}
			}

			if ( Convert.ToInt32( M.stat ) == 2 ) {
				((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " " ).item( Rand13.PickFromTable( this.attack_verb ) ).str( "s " ).item( M ).str( "'s lifeless body with " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='warning'>You " ).item( Rand13.PickFromTable( this.attack_verb ) ).str( " " ).item( M ).str( "'s lifeless body with " ).the( this ).item().str( ", trying to conjure " ).item( this.deity_name ).str( "'s mercy on them.</span>" ).ToString() );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "punch", 25, 1, -1 );
				return null;
			}
			((Ent_Static)user).visible_message( new Txt( "<span class='warning'>" ).item( user ).str( " " ).item( Rand13.PickFromTable( this.attack_verb ) ).str( "s " ).item( M ).str( "'s head with " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='warning'>You " ).item( Rand13.PickFromTable( this.attack_verb ) ).str( " " ).item( M ).str( "'s head with " ).the( this ).item().str( ". In the name of " ).item( this.deity_name ).str( ", bless thee!</span>" ).ToString() );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "punch", 25, 1, -1 );

			if ( M is Mob_Living_Carbon_Human ) {
				H2 = M;

				if ( ( GlobalVars.ticker.mode.vampires.Contains( H2.mind ) || H2.mind.vampire != null ) && !H2.mind.vampire.powers.Contains( 13 ) ) {
					GlobalFuncs.to_chat( H2, "<span class='warning'>" + this.deity_name + "'s power nullifies your own!</span>" );

					if ( H2.mind.vampire.nullified < 5 ) {
						H2.mind.vampire.nullified = Num13.MaxInt( 5, H2.mind.vampire.nullified + 2 );
					}
					H2.mind.vampire.smitecounter += 10;
				}

				if ( Lang13.Bool( GlobalVars.ticker.mode.cult.Contains( H2.mind ) ) ) {
					
					if ( Rand13.PercentChance( 20 ) ) {
						GlobalFuncs.to_chat( H2, "<span class='notice'>The power of " + this.deity_name + " suddenly clears your mind of heresy. Your allegiance to Nar'Sie wanes!</span>" );
						GlobalFuncs.to_chat( user, "<span class='notice'>You see " + H2 + "'s eyes become clear. Nar'Sie no longer controls his mind, " + this.deity_name + " saved him!</span>" );
						((GameMode)GlobalVars.ticker.mode).remove_cultist( H2.mind );
					} else {
						GlobalFuncs.to_chat( H2, "<span class='warning'>The power of " + this.deity_name + " is overwhelming you. Your mind feverishly questions Nar'Sie's teachings!</span>" );
					}
				}
				this.bless_mob( user, H2 );
			}
			return null;
		}

		// Function from file: bible.dm
		public override dynamic suicide_act( Mob_Living_Carbon_Human user = null ) {
			user.visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " is farting on " ).the( this ).item().str( "! It looks like " ).he_she_it_they().str( "'s trying to commit suicide!</span>" ).ToString() );
			user.emote( "fart" );
			Task13.Schedule( 10, (Task13.Closure)(() => {
				user.fire_stacks += 5;
				user.IgniteMob();
				user.emote( "scream", null, null, true );
				return;
				return;
			}));
			return null;
		}

	}

}