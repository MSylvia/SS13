// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Melee_Telebaton : Obj_Item_Weapon_Melee {

		public bool on = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "telebaton_0";
			this.origin_tech = "combat=2";
			this.slot_flags = 512;
			this.w_class = 2;
			this.force = 3;
			this.icon_state = "telebaton_0";
		}

		public Obj_Item_Weapon_Melee_Telebaton ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: swords_axes_etc.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			dynamic H = null;

			
			if ( this.on ) {
				
				if ( Lang13.Bool( user.mutations.Contains( 5 ) ) && Rand13.PercentChance( 50 ) ) {
					((Mob)user).simple_message( "<span class='warning'>You club yourself over the head.</span>", "<span class='danger'>The fishing rod goes mad!</span>" );
					((Mob)user).Weaken( this.force * 3 );

					if ( user is Mob_Living_Carbon_Human ) {
						H = user;
						((Mob_Living)H).apply_damage( this.force * 2, "brute", "head" );
					} else {
						((Mob_Living)user).take_organ_damage( this.force * 2 );
					}
					return null;
				}

				if ( user.a_intent == "hurt" ) {
					
					if ( !( base.attack( (object)(M), (object)(user), def_zone, eat_override ) == true ) ) {
						return null;
					}

					if ( !( M is Mob_Living_Silicon_Robot ) ) {
						GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "swing_hit", 50, 1, -1 );
						((Mob)M).Weaken( 4 );
					}
				} else {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/weapons/Genhit.ogg", 50, 1, -1 );
					((Mob)M).Weaken( 2 );
					M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been attacked with " + this.name + " by " + user.name + " (" + user.ckey + ")</font>" );
					user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Used the " + this.name + " to attack " + M.name + " (" + M.ckey + ")</font>" );
					GlobalVars.diaryofmeanpeople.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]ATTACK: " + ( "<font color='red'>" + user.name + " (" + user.ckey + ") attacked " + M.name + " (" + M.ckey + ") with " + this.name + " (INTENT: " + String13.ToUpper( user.a_intent ) + ")</font>" ) ) );
					this.add_fingerprint( user );
					((Ent_Static)M).visible_message( new Txt( "<span class='danger'>" ).item( M ).str( " has been stunned with " ).the( this ).item().str( " by " ).item( user ).str( "!</span>" ).ToString(), null, null, "<span class='notice'>" + user + " smacks " + M + " with the fishing rod!</span>" );

					if ( !( user is Mob_Living_Carbon ) ) {
						M.LAssailant = null;
					} else {
						M.LAssailant = user;
					}
				}
				return null;
			} else {
				return base.attack( (object)(M), (object)(user), def_zone, eat_override );
			}
		}

		// Function from file: swords_axes_etc.dm
		public override void generate_blood_overlay(  ) {
			Icon I = null;

			
			if ( Lang13.Bool( GlobalVars.blood_overlays["" + this.type + this.icon_state] ) ) {
				return;
			}
			I = new Icon( this.icon, this.icon_state );
			I.Blend( new Icon( "icons/effects/blood.dmi", "#ffffff" ), 0 );
			I.Blend( new Icon( "icons/effects/blood.dmi", "itemblood" ), 2 );
			GlobalVars.blood_overlays["" + this.type + this.icon_state] = new Image( I );
			return;
		}

		// Function from file: swords_axes_etc.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.on = !this.on;

			if ( this.on ) {
				((Ent_Static)user).visible_message( "<span class='warning'>With a flick of their wrist, " + user + " extends their telescopic baton.</span>", "<span class='warning'>You extend the baton.</span>", "You hear an ominous click.", "<span class='notice'>" + user + " extends their fishing rod.</span>", "<span class='notice'>You extend the fishing rod.</span>", "You hear a balloon exploding." );
				this.icon_state = "telebaton_1";
				this.item_state = "telebaton_1";
				this.w_class = 4;
				this.force = 15;
				this.attack_verb = new ByTable(new object [] { "smacked", "struck", "slapped" });
			} else {
				((Ent_Static)user).visible_message( "<span class='notice'>" + user + " collapses their telescopic baton.</span>", "<span class='notice'>You collapse the baton.</span>", "You hear a click.", "<span class='warning'>" + user + " collapses their fishing rod.</span>", "<span class='warning'>You collapse the fishing rod.</span>", "You hear a balloon exploding." );
				this.icon_state = "telebaton_0";
				this.item_state = "telebaton_0";
				this.w_class = 2;
				this.force = 3;
				this.attack_verb = new ByTable(new object [] { "hit", "punched" });
			}
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/weapons/empty.ogg", 50, 1 );
			this.add_fingerprint( user );

			if ( !Lang13.Bool( GlobalVars.blood_overlays["" + this.type + this.icon_state] ) ) {
				this.generate_blood_overlay();
			}

			if ( Lang13.Bool( this.blood_overlay ) ) {
				this.overlays.Remove( this.blood_overlay );
			}
			this.blood_overlay = GlobalVars.blood_overlays["" + this.type + this.icon_state];
			this.blood_overlay.color = this.blood_color;
			this.overlays.Add( this.blood_overlay );
			return null;
		}

	}

}